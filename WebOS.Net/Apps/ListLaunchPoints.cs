using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class ListLaunchPointsRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.ListLaunchPoints;
}

public class ListLaunchPoints : WebOSResponsePayload
{
	public List<WebOSLaunchPoint>? LaunchPoints { get; set; }
	public WebOSCaseDetail? CaseDetail { get; set; }
}

public class WebOSCaseDetail
{
	public List<object>? Change { get; set; }
}

public class WebOSLaunchPoint
{
	public string? MediumLargeIcon { get; set; }
	public string? BgColor { get; set; }
	public int? InstallTime { get; set; }
	public bool? SystemApp { get; set; }
	public string? AppDescription { get; set; }
	public string? LaunchPointId { get; set; }
	public List<string>? BgImages { get; set; }
	public string? Lptype { get; set; }
	public bool? Relaunch { get; set; }
	public string? Favicon { get; set; }
	public string? Icon { get; set; }
	public string? Id { get; set; }
	public string? BgImage { get; set; }
	public string? LargeIcon { get; set; }
	public bool? Removable { get; set; }
	public string? IconColor { get; set; }
	public string? TileSize { get; set; }
	public string? UserData { get; set; }
	public bool? Unmovable { get; set; }
	public string? ExtraLargeIcon { get; set; }
	public string? ImageForRecents { get; set; }
	public string? Miniicon { get; set; }
	public string? Title { get; set; }
	public bool? TitleVisible { get; set; }
	public WebOSPreviewMetadata? PreviewMetadata { get; set; }
}

public class WebOSPreviewMetadata
{
	public string? TargetEndpoint { get; set; }
	public string? SourceEndpoint { get; set; }
}
