namespace WebOS.Net.Apps;

public class ListLaunchPointsRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = "ssap://com.webos.applicationManager/listLaunchPoints";
}
