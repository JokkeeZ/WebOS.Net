﻿using System.Net;
using System.Net.WebSockets;
using System.Text;
using WebOS.Net.Auth;
using WebOS.Net.Services;
using WebOS.Net.System;

namespace WebOS.Net;

/// <summary>
/// Represents a client for interacting with a webOS device over WebSocket.
/// Manages connections, communication, and lifecycle of the WebSocket client.
/// </summary>
public class WebOSClient : IDisposable
{
	private CancellationTokenSource cts;
	private readonly ClientWebSocket ws;
	private bool disposed;

	public string ClientKey { get; set; } = string.Empty;

	public IPEndPoint EndPoint { get; set; }

	/// <summary>
	/// Gets a value indicating whether the client is currently paired with the webOS device.
	/// </summary>
	public bool IsPaired { get; private set; }

	/// <summary>
	/// Gets the manager for interacting with notifications on the webOS device.
	/// </summary>
	public WebOSNotificationService Notifications { get; init; }

	/// <summary>
	/// Gets the manager for interacting with applications on the webOS device.
	/// </summary>
	public WebOSAppService Apps { get; init; }

	public WebOSAudioService Audio { get; init; }

	public WebOSConnectionService ConnectionManager { get; set; }

	public WebOSSystemService System { get; init; }

	public WebOSTVService TV { get; init; }

	public WebOSControlService Control { get; set; }

	/// <summary>
	/// Gets the current state of the WebSocket connection to the webOS device.
	/// </summary>
	public WebSocketState State => ws.State;

	/// <summary>
	/// Gets a value indicating whether the WebSocket connection to the webOS device is open.
	/// </summary>
	public bool IsConnected => State == WebSocketState.Open;

	/// <summary>
	/// Gets a value indicating whether the client is active, meaning it is both connected and paired with the webOS device.
	/// </summary>
	public bool IsActive => IsConnected && IsPaired;

	/// <summary>
	/// Unique id for the requests. webOS will send the id back, so it can be used to verify what client sent the request.
	/// </summary>
	public string Id { get; }

	internal static readonly JsonSerializerOptions JsonSerializeOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	/// <summary>
	/// Initializes a new instance of the <see cref="WebOSClient"/> class with the specified webOS device.
	/// </summary>
	/// <param name="device">The webOS device to connect to and interact with.</param>
	public WebOSClient(IPEndPoint iPEndPoint, string clientKey)
	{
		Id = Guid.NewGuid().ToString();

		EndPoint = iPEndPoint;
		ClientKey = clientKey ?? string.Empty;
		ws = new();
		Notifications = new(this);
		Apps = new(this);
		Audio = new(this);
		System = new(this);
		TV = new(this);
		Control = new(this);
		ConnectionManager = new(this);
	}

	/// <summary>
	/// Establishes a WebSocket connection to the webOS device asynchronously.
	/// </summary>
	/// <param name="timeout">Connection timeout in seconds (default is 5 seconds).</param>
	/// <returns>The payload of the 'hello' response upon successful connection.</returns>
	/// <exception cref="WebOSException">Thrown when connection attempt times out or authentication fails.</exception>
	public async Task<Hello> ConnectAsync(int timeout = 5)
	{
		ws.Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
		cts = new CancellationTokenSource(TimeSpan.FromSeconds(timeout));

		try
		{
			await ws.ConnectAsync(new($"wss://{EndPoint.Address}:{EndPoint.Port}"), cts.Token);

			var hello = await HelloRequestAsync();

			if (!await RegistrationRequestAsync())
			{
				await DisconnectAsync();
			}

			IsPaired = true;

			return hello.Payload;
		}
		catch (TaskCanceledException ex)
		{
			throw new WebOSException("Connection timed out.", ex);
		}
	}

	/// <summary>
	/// Closes the WebSocket connection to the webOS device asynchronously.
	/// </summary>
	public async Task DisconnectAsync()
	{
		if (ws.State == WebSocketState.Open)
		{
			await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cts.Token);
		}
	}

	/// <summary>
	/// Cancels any ongoing asynchronous operations.
	/// </summary>
	public async Task CancelAsync() => await cts.CancelAsync();

	/// <summary>
	/// Reads a JSON response from the webOS asynchronously.
	/// </summary>
	/// <returns>The JSON response received from the device.</returns>
	public async Task<string> ReadJsonResponse()
	{
		var message = new byte[4096];
		var receivedBytes = 0;

		while (!cts.IsCancellationRequested)
		{
			var buffer = new byte[4096];
			var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), cts.Token);

			receivedBytes += result.Count;

			Array.Resize(ref message, receivedBytes);
			Array.Copy(buffer, 0, message, receivedBytes - result.Count, result.Count);

			if (result.EndOfMessage)
			{
				break;
			}
		}

		var receivedResponse = Encoding.UTF8.GetString(message, 0, receivedBytes);
#if DEBUG
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine(receivedResponse);
		Console.ResetColor();
#endif

		return receivedResponse;
	}

		/// <summary>
	/// Obtains the pointer to input socket.
	/// </summary>
	/// <returns>
	/// Returns new instance of the <see cref="GetPointerInputSocket"/> that contains socket path for the 
	/// input socket.
	/// </returns>
	/// <exception cref="WebOSException">Thrown when request attempt timeouts or invalid response is received.</exception>
	public async Task<GetPointerInputSocket> GetInputSocketAsync()
	{
		var response = await SendRequestAsync<GetPointerInputSocketRequest, GetPointerInputSocketResponse, GetPointerInputSocket>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Connects to given input socket. Input socket can be obtained from <see cref="GetInputSocketAsync"/>.
	/// </summary>
	/// <param name="socketPath">Input socket path</param>
	/// <param name="timeout">Connection timeout in seconds (default is 5 seconds).</param>
	/// <returns>
	/// Returns new instance of the <see cref="WebOSPointerInputService"/> that can be used to
	/// interract with input socket.
	/// </returns>
	/// <exception cref="ArgumentException">Thrown when socket path is null or whitespace.</exception>
	/// <exception cref="WebOSException">Thrown when connection attempt timeouts or socket path is invalid.</exception>
	public static async Task<WebOSPointerInputService> ConnectToInputSocketAsync(string socketPath, int timeout = 5)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(socketPath));

		try
		{
			var clientWebSocket = new ClientWebSocket();
			var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(timeout));
			clientWebSocket.Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

			await clientWebSocket.ConnectAsync(new(socketPath), tokenSource.Token);

			return new WebOSPointerInputService(clientWebSocket, tokenSource);
		}
		catch (TaskCanceledException ex)
		{
			throw new WebOSException("Connection timed out.", ex);
		}
	}

	internal async Task<TResponse> ReadResponseAsync<TResponse, TPayload>()
	where TResponse : WebOSResponse<TPayload>, new()
	where TPayload : WebOSResponsePayload, new()
	{
		var jsonResponse = await ReadJsonResponse();

		if (jsonResponse != null)
		{
			var response = JsonSerializer.Deserialize<TResponse>(jsonResponse, JsonSerializeOptions);

			if (response != null)
			{
				return response;
			}
		}

		return null;
	}

	internal async Task<string> SendRequestWithJsonResponseAsync<TRequest>(TRequest req)
	where TRequest : WebOSRequest, new()
	{
		req.Id = Id;
		var json = JsonSerializer.Serialize(req, JsonSerializeOptions);
#if DEBUG
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(json);
		Console.ResetColor();
#endif
		var request = Encoding.UTF8.GetBytes(json);
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cts.Token);

		var response = await ReadJsonResponse();
		return response;
	}

	internal async Task<TResponse> SendRequestAsync<TRequest, TResponse, TPayload>(TRequest req)
	where TRequest : WebOSRequest, new()
	where TResponse : WebOSResponse<TPayload>, new()
	where TPayload : WebOSResponsePayload, new()
	{
		req.Id = Id;
		var json = JsonSerializer.Serialize(req, JsonSerializeOptions);
#if DEBUG
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(json);
		Console.ResetColor();
#endif
		var request = Encoding.UTF8.GetBytes(json);
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cts.Token);

		var response = await ReadJsonResponse();
		return JsonSerializer.Deserialize<TResponse>(response, JsonSerializeOptions);
	}

	internal async Task<WebOSDefaultResponse> SendRequestAsync<TRequest>(TRequest req)
	where TRequest : WebOSRequest, new()
	{
		req.Id = Id;
		var json = JsonSerializer.Serialize(req, JsonSerializeOptions);
#if DEBUG
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(json);
		Console.ResetColor();
#endif
		var request = Encoding.UTF8.GetBytes(json);
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cts.Token);

		var response = await ReadJsonResponse();
		return JsonSerializer.Deserialize<WebOSDefaultResponse>(response, JsonSerializeOptions);
	}

	private async Task<HelloResponse> HelloRequestAsync()
	{
		var response = await SendRequestAsync<HelloRequest, HelloResponse, Hello>(new());

		if (response.Type != "hello")
		{
			throw new WebOSException("Invalid payload received!");
		}

		return response;
	}

	private async Task<bool> RegistrationRequestAsync()
	{
		var request = new RegistrationRequest();
		request.Payload.ClientKey = ClientKey;

		var response = await SendRequestAsync<RegistrationRequest, RegistrationResponse, Registration>(request);

		if (response.Type == "registered")
		{
			return true;
		}

		if (response.Type == "response" && response.Payload.PairingType == "PROMPT")
		{
			var registration = await ReadResponseAsync<RegistrationResponse, Registration>();

			if (registration.Type != "registered")
			{
				throw new WebOSException(registration.Error);
			}

			ClientKey = registration.Payload.ClientKey;
			return true;
		}

		return false;
	}

	/// <summary>
	/// Disposes of the WebSocket and cancels any ongoing operations.
	/// </summary>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Disposes of the WebSocket and cancels any ongoing operations.
	/// </summary>
	/// <param name="disposing">Whether the WebSocket should dispose or not.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				ws.Dispose();
			}

			IsPaired = false;
			disposed = true;
		}
	}
}
