using WebOS.Net.Audio;

namespace WebOS.Net.Services;

public class WebOSAudioService(WebOSClient client)
{
	public async Task<SetMute> SetMuteAsync(bool mute)
	{
		var req = new SetMuteRequest();
		req.Payload.Mute = mute;

		var response = await client.SendRequestAsync<SetMuteRequest, SetMuteResponse, SetMute>(req);

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<AudioGetStatus> GetStatusAsync()
	{
		var response = await client
			.SendRequestAsync<AudioGetStatusRequest, AudioGetStatusResponse, AudioGetStatus>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetVolume> GetVolumeAsync()
	{
		var response = await client
			.SendRequestAsync<GetVolumeRequest, GetVolumeResponse, GetVolume>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<SetVolume> SetVolumeAsync(int volume)
	{
		var request = new SetVolumeRequest();
		request.Payload.Volume = volume;

		var response = await client
			.SendRequestAsync<SetVolumeRequest, SetVolumeResponse, SetVolume>(request);

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<VolumeUp> VolumeUpAsync()
	{
		var response = await client
			.SendRequestAsync<VolumeUpRequest, VolumeUpResponse, VolumeUp>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<VolumeDown> VolumeDownAsync()
	{
		var response = await client
			.SendRequestAsync<VolumeDownRequest, VolumeDownResponse, VolumeDown>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
