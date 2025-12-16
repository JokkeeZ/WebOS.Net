using WebOS.Net.Utils;

namespace WebOS.Net.Audio;

public class VolumeDownRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.VolumeDown;
}

public class VolumeDown : WebOSResponsePayload
{
	public int Volume { get; set; }

	public string SoundOutput { get; set; }
}
