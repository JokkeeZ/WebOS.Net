using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetConfigsRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.GetConfigs;

	[JsonPropertyName("payload")]
	public GetConfigsRequestPayload Payload { get; } = new();
}

public class GetConfigsRequestPayload
{
	[JsonPropertyName("configNames")]
	public List<string> ConfigNames { get; } = [];
}

public class GetConfigsResponse : WebOSResponse<GetConfigs> { }

public class GetConfigs : WebOSResponsePayload
{
	[JsonPropertyName("configs")]
	public Dictionary<string, string> Configs { get; set; }

	[JsonPropertyName("missingConfigs")]
	public List<string> MissingConfigs { get; set; }
}
