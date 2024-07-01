using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class PlayRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Play;
}

public class PlayResponse : WebOSResponse<Play> { }

public class Play : WebOSResponsePayload { }
