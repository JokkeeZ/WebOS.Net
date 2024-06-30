using WebOS.Net.Utils;

namespace WebOS.Net.Audio;

public class GetVolumeRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetVolume;
}

public class GetVolumeResponse : WebOSResponse<GetVolume> { }

public class GetVolume : WebOSResponsePayload
{
	public string CallerId { get; set; }

	public AudioVolumeStatus VolumeStatus { get; set; }
}
