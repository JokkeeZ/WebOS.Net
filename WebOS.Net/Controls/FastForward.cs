using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class FastForwardRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.FastForward;
}
