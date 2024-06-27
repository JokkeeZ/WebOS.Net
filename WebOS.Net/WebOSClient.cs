﻿using System.Net.WebSockets;
using System.Text;
using WebOS.Net.Auth;
using WebOS.Net.Managers;

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

	/// <summary>
	/// Gets or sets the webOS device associated with this client.
	/// </summary>
	public WebOSDevice Device { get; set; }

	/// <summary>
	/// Gets a value indicating whether the client is currently paired with the webOS device.
	/// </summary>
	public bool IsPaired { get; private set; }

	/// <summary>
	/// Gets the manager for interacting with notifications on the webOS device.
	/// </summary>
	public WebOSNotificationManager Notifications { get; init; }

	/// <summary>
	/// Gets the manager for interacting with applications on the webOS device.
	/// </summary>
	public WebOSAppManager Apps { get; init; }

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
	/// Initializes a new instance of the <see cref="WebOSClient"/> class with the specified webOS device.
	/// </summary>
	/// <param name="device">The webOS device to connect to and interact with.</param>
	public WebOSClient(WebOSDevice device)
	{
		Device = device;
		ws = new();
		Notifications = new(this);
		Apps = new(this);
	}

	/// <summary>
	/// Establishes a WebSocket connection to the webOS device asynchronously.
	/// </summary>
	/// <param name="timeout">Connection timeout in seconds (default is 5 seconds).</param>
	/// <returns>The payload of the 'hello' response upon successful connection.</returns>
	/// <exception cref="WebOSException">Thrown when connection attempt times or authentication fails.</exception>
	public async Task<HelloPayload> ConnectAsync(int timeout = 5)
	{
		ws.Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
		cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

		try
		{
			await ws.ConnectAsync(new($"wss://{Device.Host}:{Device.Port}"),
				new CancellationTokenSource(TimeSpan.FromSeconds(timeout)).Token);

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
			throw new WebOSException($"Connection timed out.", ex);
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

	internal async Task<TResponse> ReadResponseAsync<TResponse, TPayload>()
	where TResponse : WebOSResponse<TPayload>, new()
	where TPayload : WebOSResponsePayload, new()
	{
		var jsonResponse = await ReadJsonResponse();

		if (jsonResponse != null)
		{
			var response = JsonSerializer.Deserialize<TResponse>(jsonResponse);

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
		var json = JsonSerializer.Serialize(req);
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
		var json = JsonSerializer.Serialize(req);
#if DEBUG
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine(json);
		Console.ResetColor();
#endif
		var request = Encoding.UTF8.GetBytes(json);
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cts.Token);

		var response = await ReadJsonResponse();
		return JsonSerializer.Deserialize<TResponse>(response);
	}

	private async Task<HelloResponse> HelloRequestAsync()
	{
		var response = await SendRequestAsync<HelloRequest, HelloResponse, HelloPayload>(new());

		if (response.Type != "hello")
		{
			throw new WebOSException("Invalid payload received!");
		}

		return response;
	}

	private async Task<bool> RegistrationRequestAsync()
	{
		var request = new RegistrationRequest();
		request.Payload.ClientKey = Device.ClientKey;

		var response = await SendRequestAsync<RegistrationRequest, RegistrationResponse, RegistrationResponsePayload>(request);

		if (response.Type == "registered")
		{
			return true;
		}

		if (response.Type == "response" && response.Payload.PairingType == "PROMPT")
		{
			var pairingResponse = await ReadResponseAsync<PairingResponse, PairingResponsePayload>();

			if (pairingResponse.Type != "registered")
			{
				throw new WebOSException(pairingResponse.Error);
			}

			if (string.IsNullOrEmpty(Device.ClientKey))
			{
				Device.ClientKey = pairingResponse.Payload.ClientKey;
			}

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