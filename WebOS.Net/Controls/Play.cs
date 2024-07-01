using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class PlayRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Play;
}
