using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class GetForegroundAppInfoRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.GetForegroundAppInfo;
}

public class GetForegroundAppInfoResponse : WebOSResponse<GetForegroundAppInfo> { }

public class GetForegroundAppInfo : WebOSResponsePayload
{
	[JsonPropertyName("appId")]
	public string AppId { get; set; }

	[JsonPropertyName("processId")]
	public string ProcessId { get; set; }

	[JsonPropertyName("windowId")]
	public string WindowId { get; set; }
}
