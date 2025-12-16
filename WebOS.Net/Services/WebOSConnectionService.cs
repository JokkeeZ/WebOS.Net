using WebOS.Net.System;

namespace WebOS.Net.Services;

/// <summary>
/// Interacts with ConnectionManager and related API calls on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSConnectionService(WebOSClient client)
{
	/// <summary>
	/// Gets connection status and details, such as is device connected to internet, WiFi name etc.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="ConnectionManagerGetStatus"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<ConnectionManagerGetStatus> GetStatusAsync()
	{
		var response = await client
			.SendRequestAsync<ConnectionManagerGetStatusRequest, ConnectionManagerGetStatus>(new());

		if (!response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Gets MAC addresses for different connection types. (WiFi, Wired and P2P)
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="ConnectionManagerGetInfo"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<ConnectionManagerGetInfo> GetInfoAsync()
	{
		var response = await client
			.SendRequestAsync<ConnectionManagerGetInfoRequest, ConnectionManagerGetInfo>(new());

		if (!response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}