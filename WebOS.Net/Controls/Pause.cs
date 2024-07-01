using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class PauseRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Pause;
}
