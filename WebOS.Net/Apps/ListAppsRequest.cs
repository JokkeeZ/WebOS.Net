namespace WebOS.Net.Apps;

public class ListAppsRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://com.webos.applicationManager/listApps";
}
