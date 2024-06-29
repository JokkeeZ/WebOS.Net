using WebOS.Net.System;

namespace WebOS.Net.Managers;

/// <summary>
/// Manages connections on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSConnectionManager(WebOSClient client)
{
	public async Task<ConnectionManagerGetStatus> GetStatusAsync()
	{
		var response = await client
			.SendRequestAsync<ConnectionManagerGetStatusRequest, ConnectionManagerGetStatusResponse, ConnectionManagerGetStatus>(new());

		if (!response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<ConnectionManagerGetInfo> GetInfoAsync()
	{
		var response = await client
			.SendRequestAsync<ConnectionManagerGetInfoRequest, ConnectionManagerGetInfoResponse, ConnectionManagerGetInfo>(new());

		if (!response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}