using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class RewindRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Rewind;
}

public class RewindResponse : WebOSResponse<Rewind> { }

public class Rewind : WebOSResponsePayload { }
