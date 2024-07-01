namespace WebOS.Net.Utils;

internal static class WebOSApiURL
{
	internal const string Close = "ssap://system.launcher/close";
	internal const string GetForegroundAppInfo = "ssap://com.webos.applicationManager/getForegroundAppInfo";
	internal const string Launch = "ssap://system.launcher/launch";
	internal const string ListApps = "ssap://com.webos.applicationManager/listApps";
	internal const string ListLaunchPoints = "ssap://com.webos.applicationManager/listLaunchPoints";
	internal const string CreateAlert = "ssap://system.notifications/createAlert";
	internal const string CreateToast = "ssap://system.notifications/createToast";
	internal const string GetConfigs = "ssap://config/getConfigs";
	internal const string GetServiceList = "ssap://api/getServiceList";
	internal const string GetSystemInfo = "ssap://system/getSystemInfo";
	internal const string GetSystemSettings = "ssap://settings/getSystemSettings";
	internal const string GetAppState = "ssap://system.launcher/getAppState";
	internal const string SetMute = "ssap://audio/setMute";
	internal const string AudioGetStatus = "ssap://audio/getStatus";
	internal const string GetVolume = "ssap://audio/getVolume";
	internal const string SetVolume = "ssap://audio/setVolume";
	internal const string VolumeUp = "ssap://audio/volumeUp";
	internal const string VolumeDown = "ssap://audio/volumeDown";
	internal const string CloseToast = "ssap://system.notifications/closeToast";
	internal const string CloseAlert = "ssap://system.notifications/closeAlert";
	internal const string GetChannelList = "ssap://tv/getChannelList";
	internal const string GetChannelProgramInfo = "ssap://tv/getChannelProgramInfo";
	internal const string GetCurrentChannel = "ssap://tv/getCurrentChannel";
	internal const string ChannelDown = "ssap://tv/channelDown";
	internal const string ChannelUp = "ssap://tv/channelUp";
	internal const string OpenChannel = "ssap://tv/openChannel";
	internal const string GetExternalInputList = "ssap://tv/getExternalInputList";
	internal const string SwitchInput = "ssap://tv/switchInput";

	// 404 no such service or method
	internal const string GetAppStatus = "ssap://com.webos.service.appstatus/getAppStatus";
	// 401 insufficient permissions
	internal const string GetCurrentSWInformation = "ssap://com.webos.service.update/getCurrentSWInformation";

	// Luna URLs
	internal const string ConnectionManagerGetInfo = "luna://com.webos.service.connectionmanager/getinfo";
	internal const string ConnectionManagerGetStatus = "luna://com.webos.service.connectionmanager/getstatus";
}
