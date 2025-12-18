using WebOS.Net.Audio;

namespace WebOS.Net.Services;

public class WebOSAudioService(WebOSClient client)
{
	public async Task<SetMute> SetMuteAsync(bool mute)
	{
		var req = new SetMuteRequest();
		req.Payload.Mute = mute;

		var response = await client.SendRequestAsync<SetMuteRequest, SetMute>(req)
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<AudioGetStatus> GetStatusAsync()
	{
		var response = await client.SendRequestAsync<AudioGetStatusRequest, AudioGetStatus>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<GetVolume> GetVolumeAsync()
	{
		var response = await client.SendRequestAsync<GetVolumeRequest, GetVolume>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<SetVolume> SetVolumeAsync(int volume)
	{
		var request = new SetVolumeRequest();
		request.Payload.Volume = volume;

		var response = await client.SendRequestAsync<SetVolumeRequest, SetVolume>(request)
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<VolumeUp> VolumeUpAsync()
	{
		var response = await client.SendRequestAsync<VolumeUpRequest, VolumeUp>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<VolumeDown> VolumeDownAsync()
	{
		var response = await client.SendRequestAsync<VolumeDownRequest, VolumeDown>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}
}
