using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class StopRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Stop;
}
