using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class GetChannelListRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetChannelList;
}

public class GetChannelList : WebOSResponsePayload
{
	public bool IpSatelliteSupport { get; set; }

	public string IpChanInteractiveUrl { get; set; }

	public string ChannelLogoServerUrl { get; set; }

	public string ValueList { get; set; }

	public int ChannelListCount { get; set; }

	public bool IpAntennaSupport { get; set; }

	public int DataSource { get; set; }

	public int DataType { get; set; }

	public bool IpOPSupport { get; set; }

	public bool IpCableSupport { get; set; }

	public WebOSTunerChannel TunerChannel { get; set; }

	public List<WebOSChannel> ChannelList { get; set; }

}

public class CASystemIDList
{
	public int CaIdCount { get; set; }

	public List<object> CaIds { get; set; }
}

public class WebOSChannel
{
	public string ChannelNumber { get; set; }

	public int MajorNumber { get; set; }

	public int MinorNumber { get; set; }

	public string ChanCode { get; set; }

	public string ChannelName { get; set; }

	public int PhysicalNumber { get; set; }

	public int SourceIndex { get; set; }

	public string ChannelType { get; set; }

	public int ChannelTypeId { get; set; }

	public string ChannelMode { get; set; }

	public int ChannelModeId { get; set; }

	public string SignalChannelId { get; set; }

	public bool Descrambled { get; set; }

	public bool Skipped { get; set; }

	public bool Locked { get; set; }

	public bool FineTuned { get; set; }

	public bool SatelliteLcn { get; set; }

	public int ShortCut { get; set; }

	public bool Scrambled { get; set; }

	public int ServiceType { get; set; }

	public int Display { get; set; }

	[JsonPropertyName("ONID")]
	public int ONID { get; set; }

	[JsonPropertyName("TSID")]
	public int TSID { get; set; }

	[JsonPropertyName("SVCID")]
	public int SVCID { get; set; }

	public string CallSign { get; set; }

	public string IpChanServerUrl { get; set; }

	public bool PayChan { get; set; }

	public string IPChannelCode { get; set; }

	public string IpCallNumber { get; set; }

	public bool OtuFlag { get; set; }

	public int AdFlag { get; set; }

	[JsonPropertyName("HDTV")]
	public bool HDTV { get; set; }

	public bool Invisible { get; set; }

	[JsonPropertyName("DTV")]
	public bool DTV { get; set; }

	[JsonPropertyName("ATV")]
	public bool ATV { get; set; }

	public bool Data { get; set; }

	public bool Radio { get; set; }

	public bool Numeric { get; set; }

	public bool PrimaryCh { get; set; }

	[JsonPropertyName("TV")]
	public bool TV { get; set; }

	public int ConfigurationId { get; set; }

	public string SatelliteName { get; set; }

	public int Bandwidth { get; set; }

	public int Frequency { get; set; }

	public bool SpecialService { get; set; }

	[JsonPropertyName("CASystemIDListCount")]
	public int CASystemIDListCount { get; set; }

	public string ChannelGenreCode { get; set; }

	public string ChannelLogoSize { get; set; }

	public string ImgUrl { get; set; }

	public string ImgUrl2 { get; set; }

	public int FavoriteIdxA { get; set; }

	public int FavoriteIdxB { get; set; }

	public int FavoriteIdxC { get; set; }

	public int FavoriteIdxD { get; set; }

	public int FavoriteIdxE { get; set; }

	public int FavoriteIdxF { get; set; }

	public int FavoriteIdxG { get; set; }

	public int FavoriteIdxH { get; set; }

	public string WaterMarkUrl { get; set; }

	public string IpChanType { get; set; }

	public bool IpChanInteractive { get; set; }

	public string IpChanCategory { get; set; }

	public string ChannelNameSortKey { get; set; }

	public string IpChanCpId { get; set; }

	public string PlayerService { get; set; }

	public bool Configured { get; set; }

	public int AdultFlag { get; set; }

	public int IsFreeviewPlay { get; set; }

	public int HasBackward { get; set; }

	public bool NumUnSel { get; set; }

	public bool RfIpChannel { get; set; }

	public List<int> GroupIdList { get; set; }

	public string LastUpdated { get; set; }

	public string ChannelId { get; set; }

	public List<object> FavoriteGroup { get; set; }

	public string ProgramId { get; set; }

	[JsonPropertyName("CASystemIDList")]
	public CASystemIDList CASystemIDList { get; set; }
}

public class ScannedChannelCount
{
	public int CableAnalogCount { get; set; }

	public int TerrestrialAnalogCount { get; set; }

	public int TerrestrialDigitalCount { get; set; }

	public int SatelliteDigitalCount { get; set; }

	public int CableDigitalCount { get; set; }
}

public class WebOSTunerChannel
{
	public ScannedChannelCount ScannedChannelCount { get; set; }

	public int DeviceSourceIndex { get; set; }

	public bool ReturnValue { get; set; }

	public bool CableAnalogSkipped { get; set; }

	public int ChannelListCount { get; set; }

	public int DataType { get; set; }

	public string ValueList { get; set; }
}
