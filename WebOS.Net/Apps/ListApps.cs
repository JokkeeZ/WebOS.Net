using WebOS.Net.Utils;

namespace WebOS.Net.Apps;

public class ListAppsRequest : WebOSRequest
{
	[JsonPropertyName("uri")]
	public string Uri { get; } = WebOSApiURL.ListApps;
}

public class ListAppsResponse : WebOSResponse<ListApps> { }

public class ListApps : WebOSResponsePayload
{
	[JsonPropertyName("apps")]
	public List<WebOSApp> Apps { get; set; } = [];
}

public class WebOSAppAccessibility
{
	[JsonPropertyName("supportsAudioGuidance")]
	public bool SupportsAudioGuidance { get; set; }
}

public class WebOSApp
{
	[JsonPropertyName("closeOnBackground")]
	public bool CloseOnBackground { get; set; }

	[JsonPropertyName("networkStableTimeout")]
	public int NetworkStableTimeout { get; set; }

	[JsonPropertyName("checkUpdateOnLaunch")]
	public bool CheckUpdateOnLaunch { get; set; }

	[JsonPropertyName("requiredPermissions")]
	public List<string> RequiredPermissions { get; set; } = [];

	[JsonPropertyName("class")]
	public WebOSAppClass Class { get; set; } = new();

	[JsonPropertyName("title")]
	public string Title { get; set; }

	[JsonPropertyName("allowWidget")]
	public bool AllowWidget { get; set; }

	[JsonPropertyName("icon")]
	public string Icon { get; set; }

	[JsonPropertyName("tileSize")]
	public string TileSize { get; set; }

	[JsonPropertyName("inAppSetting")]
	public bool InAppSetting { get; set; }

	[JsonPropertyName("closeOnRotation")]
	public bool CloseOnRotation { get; set; }

	[JsonPropertyName("nativeLifeCycleInterfaceVersion")]
	public int NativeLifeCycleInterfaceVersion { get; set; }

	[JsonPropertyName("folderPath")]
	public string FolderPath { get; set; }

	[JsonPropertyName("transparent")]
	public bool Transparent { get; set; }

	[JsonPropertyName("version")]
	public string Version { get; set; }

	[JsonPropertyName("trustLevel")]
	public string TrustLevel { get; set; }

	[JsonPropertyName("hasPromotion")]
	public bool HasPromotion { get; set; }

	[JsonPropertyName("enableCBSPolicy")]
	public bool EnableCBSPolicy { get; set; }

	[JsonPropertyName("lockable")]
	public bool Lockable { get; set; }

	[JsonPropertyName("systemApp")]
	public bool SystemApp { get; set; }

	[JsonPropertyName("mediumLargeIcon")]
	public string MediumLargeIcon { get; set; }

	[JsonPropertyName("main")]
	public string Main { get; set; }

	[JsonPropertyName("visible")]
	public bool Visible { get; set; }

	[JsonPropertyName("privilegedJail")]
	public bool PrivilegedJail { get; set; }

	[JsonPropertyName("inspectable")]
	public bool Inspectable { get; set; }

	[JsonPropertyName("defaultWindowType")]
	public string DefaultWindowType { get; set; }

	[JsonPropertyName("vendor")]
	public string Vendor { get; set; }

	[JsonPropertyName("accessibility")]
	public WebOSAppAccessibility Accessibility { get; set; } = new();

	[JsonPropertyName("deeplinkingParams")]
	public string DeeplinkingParams { get; set; }

	[JsonPropertyName("type")]
	public string Type { get; set; }

	[JsonPropertyName("supportTouchMode")]
	public string SupportTouchMode { get; set; }

	[JsonPropertyName("spinnerOnLaunch")]
	public bool SpinnerOnLaunch { get; set; }

	[JsonPropertyName("installTime")]
	public int InstallTime { get; set; }

	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("disableBackHistoryAPI")]
	public bool DisableBackHistoryAPI { get; set; }

	[JsonPropertyName("enableBackgroundRun")]
	public bool EnableBackgroundRun { get; set; }

	[JsonPropertyName("handlesRelaunch")]
	public bool HandlesRelaunch { get; set; }

	[JsonPropertyName("noSplashOnLaunch")]
	public bool NoSplashOnLaunch { get; set; }

	[JsonPropertyName("useCORSWhitelist")]
	public string UseCORSWhitelist { get; set; }

	[JsonPropertyName("removable")]
	public bool Removable { get; set; }

	[JsonPropertyName("CPApp")]
	public bool CPApp { get; set; }

	[JsonPropertyName("uiRevision")]
	public object UiRevision { get; set; }

	[JsonPropertyName("unmovable")]
	public bool Unmovable { get; set; }

	[JsonPropertyName("miniicon")]
	public string Miniicon { get; set; }

	[JsonPropertyName("appsize")]
	public int? Appsize { get; set; }

	[JsonPropertyName("inAppVoiceIntent")]
	public string InAppVoiceIntent { get; set; }

	[JsonPropertyName("internalInstallationOnly")]
	public bool? InternalInstallationOnly { get; set; }

	[JsonPropertyName("previewMetadata")]
	public WebOSAppPreviewMetadata PreviewMetadata { get; set; } = new();

	[JsonPropertyName("bgImage")]
	public string BgImage { get; set; }

	[JsonPropertyName("imageForRecents")]
	public string ImageForRecents { get; set; }

	[JsonPropertyName("binId")]
	public int? BinId { get; set; }

	[JsonPropertyName("requiredEULA")]
	public string RequiredEULA { get; set; }

	[JsonPropertyName("fileSystemType")]
	public string FileSystemType { get; set; }

	[JsonPropertyName("largeIcon")]
	public string LargeIcon { get; set; }

	[JsonPropertyName("resolution")]
	public string Resolution { get; set; }

	[JsonPropertyName("extraLargeIcon")]
	public string ExtraLargeIcon { get; set; }

	[JsonPropertyName("splashBackground")]
	public string SplashBackground { get; set; }

	[JsonPropertyName("virtualTouchHorizontalThreshold")]
	public int? VirtualTouchHorizontalThreshold { get; set; }

	[JsonPropertyName("iconColor")]
	public string IconColor { get; set; }

	[JsonPropertyName("virtualTouch")]
	public WebOSAppVirtualTouch VirtualTouch { get; set; }

	[JsonPropertyName("enablePigScreenSaver")]
	public bool? EnablePigScreenSaver { get; set; }

	[JsonPropertyName("supportQueryRouting")]
	public string SupportQueryRouting { get; set; }

	[JsonPropertyName("supportQuickStart")]
	public bool? SupportQuickStart { get; set; }

	[JsonPropertyName("standAloneLaunchable")]
	public bool? StandAloneLaunchable { get; set; }

	[JsonPropertyName("storageUseMode")]
	public string StorageUseMode { get; set; }

	[JsonPropertyName("v8SnapshotFile")]
	public string V8SnapshotFile { get; set; }

	[JsonPropertyName("useNativeScroll")]
	public bool? UseNativeScroll { get; set; }

	[JsonPropertyName("usePrerendering")]
	public bool? UsePrerendering { get; set; }

	[JsonPropertyName("sysAssetsBasePath")]
	public string SysAssetsBasePath { get; set; }

	[JsonPropertyName("supportPortraitMode")]
	public bool? SupportPortraitMode { get; set; }

	[JsonPropertyName("voiceControl")]
	public string VoiceControl { get; set; }

	[JsonPropertyName("windowGroup")]
	public WebOSAppWindowGroup WindowGroup { get; set; } = new();

	[JsonPropertyName("mediaExtension")]
	public WebOSAppMediaExtension MediaExtension { get; set; } = new();

	[JsonPropertyName("resolutionIndependent")]
	public bool? ResolutionIndependent { get; set; }

	[JsonPropertyName("handleExitKey")]
	public bool? HandleExitKey { get; set; }

	[JsonPropertyName("bgColor")]
	public string BgColor { get; set; }

	[JsonPropertyName("appDescription")]
	public string AppDescription { get; set; }

	[JsonPropertyName("supportTouchInputDevice")]
	public bool? SupportTouchInputDevice { get; set; }

	[JsonPropertyName("supportsVoiceBrowsing")]
	public bool? SupportsVoiceBrowsing { get; set; }

	[JsonPropertyName("mimeTypes")]
	public List<WebOSAppMimeType> MimeTypes { get; set; } = [];

	[JsonPropertyName("requiredMemory")]
	public int? RequiredMemory { get; set; }

	[JsonPropertyName("handleScreenRemoteKey")]
	public bool? HandleScreenRemoteKey { get; set; }

	[JsonPropertyName("bootLaunchParams")]
	public WebOSAppBootLaunchParams BootLaunchParams { get; set; } = new();

	[JsonPropertyName("supportRollingScreenMode")]
	public bool? SupportRollingScreenMode { get; set; }

	[JsonPropertyName("useGraphicCamera")]
	public bool? UseGraphicCamera { get; set; }

	[JsonPropertyName("useCamera")]
	public bool? UseCamera { get; set; }

	[JsonPropertyName("allowAudioCapture")]
	public bool? AllowAudioCapture { get; set; }

	[JsonPropertyName("allowVideoCapture")]
	public bool? AllowVideoCapture { get; set; }

	[JsonPropertyName("suspendDOMTime")]
	public int? SuspendDOMTime { get; set; }

	[JsonPropertyName("vendorExtension")]
	public WebOSAppVendorExtension VendorExtension { get; set; } = new();

	[JsonPropertyName("params")]
	public WebOSAppParams Params { get; set; }

	[JsonPropertyName("titleVisible")]
	public bool? TitleVisible { get; set; }

	[JsonPropertyName("mediumIcon")]
	public string MediumIcon { get; set; }

	[JsonPropertyName("supportGIP")]
	public bool? SupportGIP { get; set; }
}

public class WebOSAppBootLaunchParams
{
	[JsonPropertyName("BGMode")]
	public string BGMode { get; set; }

	[JsonPropertyName("boot")]
	public bool? Boot { get; set; }
}

public class WebOSAppClass
{
	[JsonPropertyName("hidden")]
	public bool Hidden { get; set; }
}

public class WebOSAppClientInfo
{
	[JsonPropertyName("layer")]
	public string Layer { get; set; }
}

public class WebOSAppLayer
{
	[JsonPropertyName("z")]
	public int Z { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }
}

public class WebOSAppMediaExtension
{
	[JsonPropertyName("ums")]
	public WebOSAppUms Ums { get; set; } = new();
}

public class WebOSAppMimeType
{
	[JsonPropertyName("extension")]
	public string Extension { get; set; }

	[JsonPropertyName("mime")]
	public string Mime { get; set; }

	[JsonPropertyName("stream")]
	public bool Stream { get; set; }

	[JsonPropertyName("scheme")]
	public string Scheme { get; set; }
}

public class WebOSAppOwnerInfo
{
	[JsonPropertyName("allowAnonymous")]
	public bool AllowAnonymous { get; set; }

	[JsonPropertyName("layers")]
	public List<WebOSAppLayer> Layers { get; set; } = [];
}

public class WebOSAppParams
{
	[JsonPropertyName("launchMode")]
	public string LaunchMode { get; set; }

	[JsonPropertyName("activateType")]
	public string ActivateType { get; set; }
}

public class WebOSAppPreviewMetadata
{
	[JsonPropertyName("targetEndpoint")]
	public string TargetEndpoint { get; set; }

	[JsonPropertyName("sourceEndpoint")]
	public string SourceEndpoint { get; set; }
}

public class WebOSAppUms
{
	[JsonPropertyName("fixedAspectRatio")]
	public string FixedAspectRatio { get; set; }
}

public class WebOSAppVendorExtension
{
	[JsonPropertyName("enableKeyboard")]
	public bool EnableKeyboard { get; set; }

	[JsonPropertyName("allowCrossDomain")]
	public bool AllowCrossDomain { get; set; }

	[JsonPropertyName("enableMouse")]
	public bool EnableMouse { get; set; }
}

public class WebOSAppVirtualTouch
{
	[JsonPropertyName("enableFocusOnPress")]
	public bool EnableFocusOnPress { get; set; }

	[JsonPropertyName("horizontalThreshold")]
	public int HorizontalThreshold { get; set; }
}

public class WebOSAppWindowGroup
{
	[JsonPropertyName("owner")]
	public bool Owner { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("clientInfo")]
	public WebOSAppClientInfo ClientInfo { get; set; } = new();

	[JsonPropertyName("ownerInfo")]
	public WebOSAppOwnerInfo OwnerInfo { get; set; } = new();
}

