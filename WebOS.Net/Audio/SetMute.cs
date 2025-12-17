using WebOS.Net.Utils;

namespace WebOS.Net.Audio;

public class SetMuteRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.SetMute;
	public SetMuteRequestPayload Payload { get; } = new();
}

public class SetMuteRequestPayload
{
	public bool? Mute { get; set; }
}

public class SetMute : WebOSResponsePayload
{
	public bool? MuteStatus { get; set; }
	public string? SoundOutput { get; set; }
}
