using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class StopRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Stop;
}

public class StopResponse : WebOSResponse<Stop> { }

public class Stop : WebOSResponsePayload { }
