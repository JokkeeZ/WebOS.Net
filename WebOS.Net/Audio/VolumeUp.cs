using WebOS.Net.Utils;

namespace WebOS.Net.Audio;

public class VolumeUpRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.VolumeUp;
}

public class VolumeUpResponse : WebOSResponse<VolumeUp> { }

public class VolumeUp : WebOSResponsePayload
{
	public int Volume { get; set; }

	public string SoundOutput { get; set; }
}
