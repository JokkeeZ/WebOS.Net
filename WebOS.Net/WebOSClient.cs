using System.Net;
using System.Net.WebSockets;
using System.Text;
using WebOS.Net.Auth;
using WebOS.Net.Services;

namespace WebOS.Net;

/// <summary>
/// Represents a client for interacting with a webOS device over WebSocket.
/// Manages connections, communication, and lifecycle of the WebSocket client.
/// </summary>
public class WebOSClient : IDisposable
{
	private readonly ClientWebSocket ws;
	private bool disposed;

	public string? ClientKey { get; set; }

	public IPEndPoint EndPoint { get; set; }

	/// <summary>
	/// Gets a value indicating whether the client is 
	/// currently paired with the webOS device.
	/// </summary>
	public bool IsPaired { get; private set; }

	/// <summary>
	/// Gets the manager for interacting with notifications on the webOS device.
	/// </summary>
	public WebOSNotificationService Notifications { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device apps.
	/// </summary>
	public WebOSAppService Apps { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device audio.
	/// </summary>
	public WebOSAudioService Audio { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device connections.
	/// </summary>
	public WebOSConnectionService ConnectionManager { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device system settings.
	/// </summary>
	public WebOSSystemService System { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device TV-specific features.
	/// </summary>
	public WebOSTVService TV { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device control features.
	/// </summary>
	public WebOSControlService Control { get; init; }

	/// <summary>
	/// Gets the service responsible for managing WebOS device inputs.
	/// </summary>
	public WebOSPointerInputService PointerInputService { get; init; }

	/// <summary>
	/// Gets the current state of the WebSocket connection to the webOS device.
	/// </summary>
	public WebSocketState State => ws.State;

	/// <summary>
	/// Gets a value indicating whether the WebSocket connection to the webOS device is open.
	/// </summary>
	public bool IsConnected => State == WebSocketState.Open;

	/// <summary>
	/// Gets a value indicating whether the client is active, 
	/// meaning it is both connected and paired with the webOS device.
	/// </summary>
	public bool IsActive => IsConnected && IsPaired;

	/// <summary>
	/// Unique id for the requests. webOS will send the id back, 
	/// so it can be used to verify what client sent the request.
	/// </summary>
	public string Id { get; }

	internal static readonly JsonSerializerOptions JsonSerializeOptions = new()
	{
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	/// <summary>
	/// Initializes a new instance of the WebOSClient class for communicating 
	/// with a webOS device at the specified network endpoint.
	/// </summary>
	/// <param name="iPEndPoint">The network endpoint of the webOS device to connect to.</param>
	/// <param name="clientKey">The client key used for authentication with the webOS device.</param>
	public WebOSClient(IPEndPoint iPEndPoint, string? clientKey = "")
	{
		Id = Guid.NewGuid().ToString();

		EndPoint = iPEndPoint;
		ClientKey = clientKey;
		ws = new();
		Notifications = new(this);
		Apps = new(this);
		Audio = new(this);
		System = new(this);
		TV = new(this);
		Control = new(this);
		ConnectionManager = new(this);
		PointerInputService = new(this);
	}

	public WebOSClient(string ipAddress, int port, string? clientKey = "")
		: this(new IPEndPoint(IPAddress.Parse(ipAddress), port), clientKey) { }

	/// <summary>
	/// Establishes a WebSocket connection to the webOS device asynchronously.
	/// </summary>
	/// <returns>The payload of the 'hello' response upon successful connection.</returns>
	/// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
	/// <exception cref="WebSocketException">Thrown when connection fails.</exception>
	/// <exception cref="WebOSException">Thrown when connection attempt times out or authentication fails.</exception>
	public async Task<Hello> ConnectAsync(CancellationToken cancellationToken = default)
	{
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
		ws.Options.RemoteCertificateValidationCallback = (_, _, _, _) => true;
#pragma warning restore CA5359 // Do Not Disable Certificate Validation

		try
		{
			await ws.ConnectAsync(new($"wss://{EndPoint.Address}:{EndPoint.Port}"), cancellationToken);

			var hello = await HelloRequestAsync(cancellationToken);

			if (!await RegistrationRequestAsync(cancellationToken))
			{
				await DisconnectAsync(cancellationToken);
			}

			IsPaired = true;

			return hello.Payload;
		}
		catch (OperationCanceledException ex)
		{
			throw new WebOSException("Connection timed out.", ex);
		}
	}

	/// <summary>
	/// Closes the WebSocket connection to the webOS device asynchronously.
	/// </summary>
	/// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
	public async Task DisconnectAsync(CancellationToken cancellationToken = default)
	{
		if (ws.State == WebSocketState.Open)
		{
			await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
		}
	}

	/// <summary>
	/// Reads a JSON response from the webOS asynchronously.
	/// </summary>
	/// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
	/// <returns>The JSON response received from the device.</returns>
	public async Task<string> ReadJsonResponse(CancellationToken cancellationToken = default)
	{
		using var stream = new MemoryStream();
		var buffer = new byte[4096];

		ValueWebSocketReceiveResult result;
		do
		{
			result = await ws.ReceiveAsync(new Memory<byte>(buffer), cancellationToken);
			stream.Write(buffer, 0, result.Count);
		}
		while (!result.EndOfMessage);

		stream.Seek(0, SeekOrigin.Begin);

		using var reader = new StreamReader(stream, Encoding.UTF8);
		var receivedResponse = await reader.ReadToEndAsync(cancellationToken);

#if DEBUG
		Console.ForegroundColor = ConsoleColor.DarkYellow;
		Console.WriteLine(receivedResponse);
		Console.ResetColor();
#endif

		return receivedResponse;
	}

	internal async Task<WebOSResponse<TPayload>?> ReadResponseAsync<TPayload>(CancellationToken cancellationToken = default)
	where TPayload : WebOSResponsePayload, new()
	{
		var jsonResponse = await ReadJsonResponse(cancellationToken);

		if (jsonResponse != null)
		{
			var response = JsonSerializer.Deserialize<WebOSResponse<TPayload>>(jsonResponse, JsonSerializeOptions);

			if (response != null)
			{
				return response;
			}
		}

		return null;
	}

	internal async Task<string> SendRequestWithJsonResponseAsync<TRequest>(TRequest req, CancellationToken cancellationToken = default)
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
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cancellationToken);

		var response = await ReadJsonResponse(cancellationToken);
		return response;
	}

	internal async Task<WebOSResponse<TPayload>?> SendRequestAsync<TRequest, TPayload>(TRequest req, CancellationToken cancellationToken = default)
	where TRequest : WebOSRequest, new()
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
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cancellationToken);

		var response = await ReadJsonResponse(cancellationToken);
		return JsonSerializer.Deserialize<WebOSResponse<TPayload>>(response, JsonSerializeOptions);
	}

	internal async Task<WebOSDefaultResponse?> SendRequestAsync<TRequest>(TRequest req, CancellationToken cancellationToken = default)
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
		await ws.SendAsync(new ArraySegment<byte>(request), WebSocketMessageType.Text, true, cancellationToken);

		var response = await ReadJsonResponse(cancellationToken);
		return JsonSerializer.Deserialize<WebOSDefaultResponse>(response, JsonSerializeOptions);
	}

	private async Task<WebOSResponse<Hello>> HelloRequestAsync(CancellationToken cancellationToken = default)
	{
		var response = await SendRequestAsync<HelloRequest, Hello>(new(), cancellationToken)
			?? throw new WebOSException("No response received from the device.");

		if (response.Type != "hello")
		{
			throw new WebOSException("Invalid payload received!");
		}

		return response;
	}

	private async Task<bool> RegistrationRequestAsync(CancellationToken cancellationToken = default)
	{
		var request = new RegistrationRequest();
		request.Payload.ClientKey = ClientKey ?? string.Empty;

		var response = await SendRequestAsync<RegistrationRequest, Registration>(request, cancellationToken)
			?? throw new WebOSException("No response received from the device.");

		if (response.Type == "registered")
		{
			return true;
		}

		if (response.Type == "response" && response.Payload.PairingType == "PROMPT")
		{
			var registration = await ReadResponseAsync<Registration>(cancellationToken)
				?? throw new WebOSException("Invalid payload received!");

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
