using WebOS.Net.Utils;

namespace WebOS.Net.TV;

public class GetChannelProgramInfoRequest : WebOSRequest
{
	public override string Uri => WebOSApiURL.GetChannelProgramInfo;
}

public class GetChannelProgramInfo : WebOSResponsePayload
{
	public WebOSChannel? Channel { get; set; }
	public List<WebOSProgram>? ProgramList { get; set; }
}

public class WebOSProgram
{
	public string? ChannelId { get; set; }
	public int? Duration { get; set; }
	public string? EndTime { get; set; }
	public string? LocalEndTime { get; set; }
	public string? LocalStartTime { get; set; }
	public string? Genre { get; set; }
	public string? ProgramId { get; set; }
	public string? ProgramName { get; set; }
	public List<WebOSProgramRating>? Rating { get; set; }
	public string? SignalChannelId { get; set; }
	public string? StartTime { get; set; }
	public int? TableId { get; set; }
}

public class WebOSProgramRating
{
	public int? RatingValue { get; set; }
	public string? Id { get; set; }
	public string? RatingString { get; set; }
	public int? Region { get; set; }
}
