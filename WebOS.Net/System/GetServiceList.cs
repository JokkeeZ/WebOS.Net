using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetServiceListRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.GetServiceList;
}

public class GetServiceListResponse : WebOSResponse<GetServiceList> { }

public class GetServiceList : WebOSResponsePayload
{
	[JsonPropertyName("services")]
	public List<WebOSService> Services { get; set; }
}

public class WebOSService
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("version")]
	public int Version { get; set; }
}
