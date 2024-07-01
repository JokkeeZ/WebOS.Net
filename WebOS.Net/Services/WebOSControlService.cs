using WebOS.Net.Controls;

namespace WebOS.Net.Services;

public class WebOSControlService(WebOSClient client)
{
	public async Task<WebOSResponsePayload> PlayAsync()
	{
		var response = await client.SendRequestAsync<PlayRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> StopAsync()
	{
		var response = await client.SendRequestAsync<StopRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> PauseAsync()
	{
		var response = await client.SendRequestAsync<PauseRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> RewindAsync()
	{
		var response = await client.SendRequestAsync<RewindRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> FastForwardAsync()
	{
		var response = await client.SendRequestAsync<FastForwardRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
