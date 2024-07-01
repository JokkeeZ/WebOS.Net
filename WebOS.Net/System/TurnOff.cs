using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class TurnOffRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.TurnOff;
}

public class TurnOffResponse : WebOSResponse<TurnOff> { }

public class TurnOff : WebOSResponsePayload { }