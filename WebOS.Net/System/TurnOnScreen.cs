using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class TurnOnScreenRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.TurnOnScreen;
}

public class TurnOnScreenResponse : WebOSResponse<TurnOnScreen> { }

public class TurnOnScreen : WebOSResponsePayload
{
	public string State { get; set; }
}
