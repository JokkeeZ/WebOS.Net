using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetSystemInfoRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.GetSystemInfo;
}

public class GetSystemInfo : WebOSResponsePayload
{
	public WebOSSystemInfoFeatures? Features { get; set; }
	public string? ReceiverType { get; set; }
	public string? ModelName { get; set; }
	public string? SerialNumber { get; set; }
	public bool? ProgramMode { get; set; }
}

public class WebOSSystemInfoFeatures
{
	public bool? Dvr { get; set; }
}
