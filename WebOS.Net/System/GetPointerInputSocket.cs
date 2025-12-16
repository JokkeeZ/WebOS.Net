using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class GetPointerInputSocketRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetPointerInputSocket;
}

public class GetPointerInputSocket : WebOSResponsePayload
{
	public string SocketPath { get; set; }
}
