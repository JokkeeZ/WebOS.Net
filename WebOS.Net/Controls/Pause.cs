using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class PauseRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Pause;
}

public class PauseResponse : WebOSResponse<Pause> { }

public class Pause : WebOSResponsePayload { }
