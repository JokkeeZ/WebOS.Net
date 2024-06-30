using WebOS.Net.Audio;

namespace WebOS.Net.Managers;

public class WebOSAudioManager(WebOSClient client)
{
	public async Task<SetMute> SetMuteAsync(bool mute)
	{
		var req = new SetMuteRequest();
		req.Payload.Mute = mute;

		var response = await client.SendRequestAsync<SetMuteRequest, SetMuteResponse, SetMute>(req);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<AudioGetStatus> GetStatusAsync()
	{
		var response = await client
			.SendRequestAsync<AudioGetStatusRequest, AudioGetStatusResponse, AudioGetStatus>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
