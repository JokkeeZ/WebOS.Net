using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetServiceListRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.GetServiceList;
}

public class GetServiceListResponse : WebOSResponse<GetServiceList> { }

public class GetServiceList : WebOSResponsePayload
{
	public List<WebOSService> Services { get; set; }
}

public class WebOSService
{
	public string Name { get; set; }

	public int Version { get; set; }
}
