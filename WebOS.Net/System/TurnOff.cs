using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class TurnOffRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.TurnOff;
}
