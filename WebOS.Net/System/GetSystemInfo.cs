using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetSystemInfoRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.GetSystemInfo;
}

public class GetSystemInfoResponse : WebOSResponse<GetSystemInfo> { }

public class GetSystemInfo : WebOSResponsePayload
{
	[JsonPropertyName("features")]
	public WebOSSystemInfoFeatures Features { get; set; }

	[JsonPropertyName("receiverType")]
	public string ReceiverType { get; set; }

	[JsonPropertyName("modelName")]
	public string ModelName { get; set; }

	[JsonPropertyName("serialNumber")]
	public string SerialNumber { get; set; }

	[JsonPropertyName("programMode")]
	public bool ProgramMode { get; set; }
}

public class WebOSSystemInfoFeatures
{
	[JsonPropertyName("dvr")]
	public bool Dvr { get; set; }
}
