using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class ChannelUpRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.ChannelUp;
}

public class ChannelUpResponse : WebOSResponse<ChannelUp> { }

public class ChannelUp : WebOSResponsePayload { }
