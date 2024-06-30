using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class ConnectionManagerGetInfoRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.ConnectionManagerGetInfo;
}

public class ConnectionManagerGetInfoResponse : WebOSResponse<ConnectionManagerGetInfo> { }

public class ConnectionManagerGetInfo : WebOSResponsePayload
{
	public WebOSConnectionInfo WifiInfo { get; set; }

	public WebOSConnectionInfo WiredInfo { get; set; }

	public WebOSConnectionInfo P2pInfo { get; set; }
}

public class WebOSConnectionInfo
{
	public string MacAddress { get; set; }
}
