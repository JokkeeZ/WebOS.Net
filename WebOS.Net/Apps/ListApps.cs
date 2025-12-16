using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class ListAppsRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.ListApps;
}

public class ListApps : WebOSResponsePayload
{
	public List<WebOSApp> Apps { get; set; } = [];
}

public class WebOSAppAccessibility
{
	public bool SupportsAudioGuidance { get; set; }
}

public class WebOSApp
{
	public bool CloseOnBackground { get; set; }

	public int NetworkStableTimeout { get; set; }

	public bool CheckUpdateOnLaunch { get; set; }

	public List<string> RequiredPermissions { get; set; } = [];

	public WebOSAppClass Class { get; set; } = new();

	public string Title { get; set; }

	public bool AllowWidget { get; set; }

	public string Icon { get; set; }

	public string TileSize { get; set; }

	public bool InAppSetting { get; set; }

	public bool CloseOnRotation { get; set; }

	public int NativeLifeCycleInterfaceVersion { get; set; }

	public string FolderPath { get; set; }

	public bool Transparent { get; set; }

	public string Version { get; set; }

	public string TrustLevel { get; set; }

	public bool HasPromotion { get; set; }

	public bool EnableCBSPolicy { get; set; }

	public bool Lockable { get; set; }

	public bool SystemApp { get; set; }

	public string MediumLargeIcon { get; set; }

	public string Main { get; set; }

	public bool Visible { get; set; }

	public bool PrivilegedJail { get; set; }

	public bool Inspectable { get; set; }

	public string DefaultWindowType { get; set; }

	public string Vendor { get; set; }

	public WebOSAppAccessibility Accessibility { get; set; } = new();

	public string DeeplinkingParams { get; set; }

	public string Type { get; set; }

	public string SupportTouchMode { get; set; }

	public bool SpinnerOnLaunch { get; set; }

	public int InstallTime { get; set; }

	public string Id { get; set; }

	public bool DisableBackHistoryAPI { get; set; }

	public bool EnableBackgroundRun { get; set; }

	public bool HandlesRelaunch { get; set; }

	public bool NoSplashOnLaunch { get; set; }

	public string UseCORSWhitelist { get; set; }

	public bool Removable { get; set; }

	public bool CPApp { get; set; }

	public object UiRevision { get; set; }

	public bool Unmovable { get; set; }

	public string Miniicon { get; set; }

	public int? Appsize { get; set; }

	public string InAppVoiceIntent { get; set; }

	public bool? InternalInstallationOnly { get; set; }

	public WebOSAppPreviewMetadata PreviewMetadata { get; set; } = new();

	public string BgImage { get; set; }

	public string ImageForRecents { get; set; }

	public int? BinId { get; set; }

	public string RequiredEULA { get; set; }

	public string FileSystemType { get; set; }

	public string LargeIcon { get; set; }

	public string Resolution { get; set; }

	public string ExtraLargeIcon { get; set; }

	public string SplashBackground { get; set; }

	public int? VirtualTouchHorizontalThreshold { get; set; }

	public string IconColor { get; set; }

	public WebOSAppVirtualTouch VirtualTouch { get; set; }

	public bool? EnablePigScreenSaver { get; set; }

	public string SupportQueryRouting { get; set; }

	public bool? SupportQuickStart { get; set; }

	public bool? StandAloneLaunchable { get; set; }

	public string StorageUseMode { get; set; }

	public string V8SnapshotFile { get; set; }

	public bool? UseNativeScroll { get; set; }

	public bool? UsePrerendering { get; set; }

	public string SysAssetsBasePath { get; set; }

	public bool? SupportPortraitMode { get; set; }

	public string VoiceControl { get; set; }

	public WebOSAppWindowGroup WindowGroup { get; set; } = new();

	public WebOSAppMediaExtension MediaExtension { get; set; } = new();

	public bool? ResolutionIndependent { get; set; }

	public bool? HandleExitKey { get; set; }

	public string BgColor { get; set; }

	public string AppDescription { get; set; }

	public bool? SupportTouchInputDevice { get; set; }

	public bool? SupportsVoiceBrowsing { get; set; }

	public List<WebOSAppMimeType> MimeTypes { get; set; } = [];

	public int? RequiredMemory { get; set; }

	public bool? HandleScreenRemoteKey { get; set; }

	public WebOSAppBootLaunchParams BootLaunchParams { get; set; } = new();

	public bool? SupportRollingScreenMode { get; set; }

	public bool? UseGraphicCamera { get; set; }

	public bool? UseCamera { get; set; }

	public bool? AllowAudioCapture { get; set; }

	public bool? AllowVideoCapture { get; set; }

	public int? SuspendDOMTime { get; set; }

	public WebOSAppVendorExtension VendorExtension { get; set; } = new();

	public WebOSAppParams Params { get; set; }

	public bool? TitleVisible { get; set; }

	public string MediumIcon { get; set; }

	public bool? SupportGIP { get; set; }
}

public class WebOSAppBootLaunchParams
{
	public string BGMode { get; set; }

	public bool? Boot { get; set; }
}

public class WebOSAppClass
{
	public bool Hidden { get; set; }
}

public class WebOSAppClientInfo
{
	public string Layer { get; set; }
}

public class WebOSAppLayer
{
	public int Z { get; set; }

	public string Name { get; set; }
}

public class WebOSAppMediaExtension
{
	public WebOSAppUms Ums { get; set; } = new();
}

public class WebOSAppMimeType
{
	public string Extension { get; set; }

	public string Mime { get; set; }

	public bool Stream { get; set; }

	public string Scheme { get; set; }
}

public class WebOSAppOwnerInfo
{
	public bool AllowAnonymous { get; set; }

	public List<WebOSAppLayer> Layers { get; set; } = [];
}

public class WebOSAppParams
{
	public string LaunchMode { get; set; }

	public string ActivateType { get; set; }
}

public class WebOSAppPreviewMetadata
{
	public string TargetEndpoint { get; set; }

	public string SourceEndpoint { get; set; }
}

public class WebOSAppUms
{
	public string FixedAspectRatio { get; set; }
}

public class WebOSAppVendorExtension
{
	public bool EnableKeyboard { get; set; }

	public bool AllowCrossDomain { get; set; }

	public bool EnableMouse { get; set; }
}

public class WebOSAppVirtualTouch
{
	public bool EnableFocusOnPress { get; set; }

	public int HorizontalThreshold { get; set; }
}

public class WebOSAppWindowGroup
{
	public bool Owner { get; set; }

	public string Name { get; set; }

	public WebOSAppClientInfo ClientInfo { get; set; } = new();

	public WebOSAppOwnerInfo OwnerInfo { get; set; } = new();
}

