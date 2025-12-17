using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetPowerStateRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetPowerState;
}

public class GetPowerState : WebOSResponsePayload
{
	public string? State { get; set; }
}
