using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class ChannelDownRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.ChannelDown;
}
