using System.Net.WebSockets;
using System.Text;

namespace WebOS.Net.Services;

/// <summary>
/// Represents connection to webOS Pointer Input Socket. Pointer is obtained from
/// request to <c>ssap://com.webos.service.networkinput/getPointerInputSocket</c>
/// </summary>
/// <param name="ws">Active WebSocket connection to the input socket.</param>
/// <param name="cts">CancellationToken for cancelling the connection and requets.</param>
public class WebOSPointerInputService(ClientWebSocket ws, CancellationTokenSource cts) : IDisposable
{
	private bool disposed;

	/// <summary>
	/// Sends button click to the input socket.
	/// </summary>
	/// <param name="button">Button name.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public async Task SendButtonAsync(string button)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(button));

		var payload = Encoding.UTF8.GetBytes($"type:button\nname:{button}\n\n");
		await ws.SendAsync(new ArraySegment<byte>(payload), WebSocketMessageType.Text, true, cts.Token);
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
				cts.Dispose();
			}

			disposed = true;
		}
	}
}
