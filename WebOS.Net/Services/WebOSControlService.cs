using WebOS.Net.Controls;

namespace WebOS.Net.Services;

public class WebOSControlService(WebOSClient client)
{
	public async Task<WebOSResponsePayload> PlayAsync()
	{
		var response = await client.SendRequestAsync<PlayRequest>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> StopAsync()
	{
		var response = await client.SendRequestAsync<StopRequest>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> PauseAsync()
	{
		var response = await client.SendRequestAsync<PauseRequest>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> RewindAsync()
	{
		var response = await client.SendRequestAsync<RewindRequest>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> FastForwardAsync()
	{
		var response = await client.SendRequestAsync<FastForwardRequest>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}
}
