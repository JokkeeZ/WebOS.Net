using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class GetExternalInputListRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetExternalInputList;
}

public class GetExternalInputListResponse : WebOSResponse<GetExternalInputList> { }

public class GetExternalInputList : WebOSResponsePayload
{
	public List<ExternalInputDevice> Devices { get; set; }
}

public class ExternalInputDevice
{
	public string Id { get; set; }
	public string Label { get; set; }
	public int Port { get; set; }
	public bool Connected { get; set; }
	public string AppId { get; set; }
	public string Icon { get; set; }
	public bool ForceIcon { get; set; }
	public bool Modified { get; set; }
	public int LastUniqueId { get; set; }
	public bool HdmiPlugIn { get; set; }
	public List<object> SubList { get; set; }
	public int SubCount { get; set; }
	public bool Favorite { get; set; }
}

