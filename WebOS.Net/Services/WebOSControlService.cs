using WebOS.Net.Controls;

namespace WebOS.Net.Services;

public class WebOSControlService(WebOSClient client)
{
	public async Task<Play> PlayAsync()
	{
		var response = await client.SendRequestAsync<PlayRequest, PlayResponse, Play>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<Stop> StopAsync()
	{
		var response = await client.SendRequestAsync<StopRequest, StopResponse, Stop>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<Pause> PauseAsync()
	{
		var response = await client.SendRequestAsync<PauseRequest, PauseResponse, Pause>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<Rewind> RewindAsync()
	{
		var response = await client.SendRequestAsync<RewindRequest, RewindResponse, Rewind>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<FastForward> FastForwardAsync()
	{
		var response = await client.SendRequestAsync<FastForwardRequest, FastForwardResponse, FastForward>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
