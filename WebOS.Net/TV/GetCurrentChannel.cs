using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class GetCurrentChannelRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetCurrentChannel;
}

public class GetCurrentChannel : WebOSResponsePayload
{
	public string ChannelTypeName { get; set; }
	public string ChannelNumber { get; set; }
	public bool IsChannelChanged { get; set; }
	public string ChannelName { get; set; }
	public bool IsInteractiveRestrictionChannel { get; set; }
	public bool IsSkipped { get; set; }
	public bool IsReplaceChannel { get; set; }
	public bool IsLocked { get; set; }
	public bool IsHEVCChannel { get; set; }
	public int ChannelModeId { get; set; }
	public bool IsInvisible { get; set; }
	public bool IsScrambled { get; set; }
	public string SignalChannelId { get; set; }
	public int PhysicalNumber { get; set; }
	public string HybridtvType { get; set; }
	public bool IsDescrambled { get; set; }
	public string ChannelModeName { get; set; }
	public string ChannelId { get; set; }
	public object FavoriteGroup { get; set; }
	public int ChannelTypeId { get; set; }
	public bool IsFineTuned { get; set; }
	public WebOSDualChannel DualChannel { get; set; }
}

public class WebOSDualChannel
{
	public object DualChannelTypeName { get; set; }
	public object DualChannelNumber { get; set; }
	public object DualChannelId { get; set; }
	public int DualChannelTypeId { get; set; }
}
