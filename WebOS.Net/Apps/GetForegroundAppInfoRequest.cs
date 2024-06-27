namespace WebOS.Net.Apps;

public class GetForegroundAppInfoRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://com.webos.applicationManager/getForegroundAppInfo";
}
