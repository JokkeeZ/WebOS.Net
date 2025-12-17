using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class TurnOffScreenRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.TurnOffScreen;
}

public class TurnOffScreen : WebOSResponsePayload
{
	public string? State { get; set; }
}
