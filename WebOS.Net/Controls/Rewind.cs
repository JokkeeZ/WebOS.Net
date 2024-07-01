using WebOS.Net.Utils;

namespace WebOS.Net.Controls;

public class RewindRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.Rewind;
}
