using System.Net.WebSockets;
using System.Text;
using WebOS.Net.System;

namespace WebOS.Net.Services;

/// <summary>
/// Represents connection to webOS Pointer Input Socket. Pointer is obtained from
/// request to <c>ssap://com.webos.service.networkinput/getPointerInputSocket</c>
/// </summary>
/// <param name="timeout">Connection timeout in seconds.</param>
public class WebOSPointerInputService(WebOSClient client) : IDisposable
{
	private readonly ClientWebSocket ws = new();

	private bool disposed;

	/// <summary>
	/// Obtains the pointer to input socket.
	/// </summary>
	/// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
	/// <returns>
	/// Returns new instance of the <see cref="GetPointerInputSocket"/> that contains socket path for the 
	/// input socket.
	/// </returns>
	/// <exception cref="WebOSException">Thrown when request attempt timeouts or invalid response is received.</exception>
	public async Task<GetPointerInputSocket> GetInputSocketAsync(CancellationToken cancellationToken = default)
	{
		var response = await client.SendRequestAsync<GetPointerInputSocketRequest, GetPointerInputSocket>(new(), cancellationToken);

		return response is null
			? throw new WebOSException("No response received from the device.")
			: response.Payload;
	}

	/// <summary>
	/// Asynchronously establishes a WebSocket connection to the specified socket path.
	/// </summary>
	/// <param name="socketPath">The URI or file system path of the socket endpoint to connect to. Cannot be null or empty.</param>
	/// <param name="cancellationToken">A cancellation token used to propagate notification that the operation should be canceled.</param>
	/// <returns>A task that represents the asynchronous connection operation.</returns>
	/// <exception cref="WebOSException">Thrown if the connection attempt is canceled or times out.</exception>
	public async Task CreateConnectionAsync(string socketPath, CancellationToken cancellationToken = default)
	{
		try
		{
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
			ws.Options.RemoteCertificateValidationCallback = (_, _, _, _) => true;
#pragma warning restore CA5359 // Do Not Disable Certificate Validation

			await ws.ConnectAsync(new(socketPath), cancellationToken);
		}
		catch (OperationCanceledException ex)
		{
			throw new WebOSException("Connection timed out.", ex);
		}
	}

	/// <summary>
	/// Sends button click to the input socket.
	/// </summary>
	/// <param name="button">Button name.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public async Task SendButtonAsync(string button, CancellationToken cancellationToken = default)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(button));

		try
		{
			var payload = Encoding.UTF8.GetBytes($"type:button\nname:{button}\n\n");
			await ws.SendAsync(new ArraySegment<byte>(payload), WebSocketMessageType.Text, true, cancellationToken);
		}
		catch (Exception ex)
		{
			throw new WebOSException("Failed to send a button to the WebOS device.", ex);
		}
	}

	/// <summary>
	/// Disposes the WebSocket and CancellationToken and cancels any ongoing operations.
	/// </summary>
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	/// <summary>
	/// Disposes the WebSocket and cancels any ongoing operations.
	/// </summary>
	/// <param name="disposing">Whether the object should dispose or not.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				ws.Dispose();
			}

			disposed = true;
		}
	}
}
