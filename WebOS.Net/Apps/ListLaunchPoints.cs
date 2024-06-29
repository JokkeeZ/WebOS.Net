using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class ListLaunchPointsRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.ListLaunchPoints;
}

public class ListLaunchPointsResponse : WebOSResponse<ListLaunchPoints> { }

public class ListLaunchPoints : WebOSResponsePayload
{
	[JsonPropertyName("launchPoints")]
	public List<WebOSLaunchPoint> LaunchPoints { get; set; } = [];

	[JsonPropertyName("caseDetail")]
	public WebOSCaseDetail CaseDetail { get; set; } = new();
}

public class WebOSCaseDetail
{
	[JsonPropertyName("change")]
	public List<object> Change { get; set; } = [];
}

public class WebOSLaunchPoint
{
	[JsonPropertyName("mediumLargeIcon")]
	public string MediumLargeIcon { get; set; }

	[JsonPropertyName("bgColor")]
	public string BgColor { get; set; }

	[JsonPropertyName("installTime")]
	public int InstallTime { get; set; }

	[JsonPropertyName("systemApp")]
	public bool SystemApp { get; set; }

	[JsonPropertyName("appDescription")]
	public string AppDescription { get; set; }

	[JsonPropertyName("launchPointId")]
	public string LaunchPointId { get; set; }

	[JsonPropertyName("bgImages")]
	public List<string> BgImages { get; set; } = [];

	[JsonPropertyName("lptype")]
	public string Lptype { get; set; }

	[JsonPropertyName("relaunch")]
	public bool Relaunch { get; set; }

	[JsonPropertyName("favicon")]
	public string Favicon { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; }

	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("bgImage")]
	public string BgImage { get; set; }

	[JsonPropertyName("largeIcon")]
	public string LargeIcon { get; set; }

	[JsonPropertyName("removable")]
	public bool Removable { get; set; }

	[JsonPropertyName("iconColor")]
	public string IconColor { get; set; }

	[JsonPropertyName("tileSize")]
	public string TileSize { get; set; }

	[JsonPropertyName("userData")]
	public string UserData { get; set; }

	[JsonPropertyName("unmovable")]
	public bool Unmovable { get; set; }

	[JsonPropertyName("extraLargeIcon")]
	public string ExtraLargeIcon { get; set; }

	[JsonPropertyName("imageForRecents")]
	public string ImageForRecents { get; set; }

	[JsonPropertyName("miniicon")]
	public string Miniicon { get; set; }

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("titleVisible")]
	public bool TitleVisible { get; set; }

	[JsonPropertyName("previewMetadata")]
	public WebOSPreviewMetadata PreviewMetadata { get; set; } = new();
}

public class WebOSPreviewMetadata
{
	[JsonPropertyName("targetEndpoint")]
	public string TargetEndpoint { get; set; }

	[JsonPropertyName("sourceEndpoint")]
	public string SourceEndpoint { get; set; }
}
