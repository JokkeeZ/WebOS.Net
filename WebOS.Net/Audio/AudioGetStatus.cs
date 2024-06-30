using WebOS.Net.Utils;

namespace WebOS.Net.Audio;

public class AudioGetStatusRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.AudioGetStatus;
}

public class AudioGetStatusResponse : WebOSResponse<AudioGetStatus> { }

public class AudioGetStatus : WebOSResponsePayload
{
	public string CallerId { get; set; }

	public bool Mute { get; set; }

	public int Volume { get; set; }

	public AudioVolumeStatus VolumeStatus { get; set; }
}

public class AudioVolumeStatus
{
	public bool VolumeLimitable { get; set; }

	public bool ActiveStatus { get; set; }

	public int MaxVolume { get; set; }

	public string VolumeLimiter { get; set; }

	public string SoundOutput { get; set; }

	public int Volume { get; set; }

	public string Mode { get; set; }

	public bool ExternalDeviceControl { get; set; }

	public bool MuteStatus { get; set; }

	public bool VolumeSyncable { get; set; }

	public bool AdjustVolume { get; set; }
}
