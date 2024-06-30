using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetConfigsRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.GetConfigs;

	public GetConfigsRequestPayload Payload { get; } = new();
}

public class GetConfigsRequestPayload
{
	public List<string> ConfigNames { get; } = [];
}

public class GetConfigsResponse : WebOSResponse<GetConfigs> { }

public class GetConfigs : WebOSResponsePayload
{
	public Dictionary<string, object> Configs { get; set; }

	public List<string> MissingConfigs { get; set; }
}
