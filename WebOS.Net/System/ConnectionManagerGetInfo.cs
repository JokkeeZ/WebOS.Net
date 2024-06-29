using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class ConnectionManagerGetInfoRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.ConnectionManagerGetInfo;
}

public class ConnectionManagerGetInfoResponse : WebOSResponse<ConnectionManagerGetInfo> { }

public class ConnectionManagerGetInfo : WebOSResponsePayload
{
	[JsonPropertyName("wifiInfo")]
	public WebOSConnectionInfo WifiInfo { get; set; }

	[JsonPropertyName("wiredInfo")]
	public WebOSConnectionInfo WiredInfo { get; set; }

	[JsonPropertyName("p2pInfo")]
	public WebOSConnectionInfo P2PInfo { get; set; }
}

public class WebOSConnectionInfo
{
	[JsonPropertyName("macAddress")]
	public string MacAddress { get; set; }
}
