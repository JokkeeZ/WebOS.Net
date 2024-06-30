using WebOS.Net.Utils;

namespace WebOS.Net.Audio;

public class SetVolumeRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.SetVolume;

	public SetVolumeRequestPayload Payload { get; } = new();
}

public class SetVolumeRequestPayload
{
	public int Volume { get; set; }
}

public class SetVolumeResponse : WebOSResponse<SetVolume> { }

public class SetVolume : WebOSResponsePayload
{
	public int Volume { get; set; }

	public string SoundOutput { get; set; }
}
