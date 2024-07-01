using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class ChannelDownRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.ChannelDown;
}

public class ChannelDownResponse : WebOSResponse<ChannelDown> { }

public class ChannelDown : WebOSResponsePayload { }
