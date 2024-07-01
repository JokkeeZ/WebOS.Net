using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class OpenChannelRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.OpenChannel;

	public OpenChannelRequestPayload Payload { get; } = new();
}

public class OpenChannelRequestPayload
{
	public string ChannelNumber { get; set; }
}

public class OpenChannelResponse : WebOSResponse<OpenChannel> { }

public class OpenChannel : WebOSResponsePayload { }
