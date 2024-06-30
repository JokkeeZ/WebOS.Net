using WebOS.Net.Utils;

namespace WebOS.Net.System;

public class ConnectionManagerGetStatusRequest : WebOSRequest
{
	public override string Uri { get; } = WebOSApiURL.ConnectionManagerGetStatus;
}

public class ConnectionManagerGetStatusResponse : WebOSResponse<ConnectionManagerGetStatus> { }

public class ConnectionManagerGetStatus : WebOSResponsePayload
{
	public WebOSWifiDirect WifiDirect { get; set; }

	public WebOSWifi Wifi { get; set; }

	public WebOSWan Wan { get; set; }

	public string OfflineMode { get; set; }

	public WebOSWired Wired { get; set; }

	public WebOSCellular Cellular { get; set; }

	public WebOSBluetooth Bluetooth { get; set; }

	public bool IsInternetConnectionAvailable { get; set; }
}

public class WebOSBluetooth
{
	public bool TetheringEnabled { get; set; }

	public string State { get; set; }
}

public class WebOSCellular
{
	public bool Enabled { get; set; }
}

public class WebOSProxyInfo
{
	public string Url { get; set; }

	public string Method { get; set; }
}

public class WebOSWan
{
	public List<object> ConnectedContexts { get; set; }

	public bool Connected { get; set; }
}

public class WebOSWifi
{
	public string Netmask { get; set; }

	public string ConnectedChannel { get; set; }

	public string Method { get; set; }

	public string Dns1 { get; set; }

	public string InterfaceName { get; set; }

	public string Gateway { get; set; }

	public string DisplayName { get; set; }

	public string Dns2 { get; set; }

	public WebOSProxyInfo Proxyinfo { get; set; }

	public string IpAddress { get; set; }

	public bool CheckingInternet { get; set; }

	public bool IsWakeOnWifiEnabled { get; set; }

	public string State { get; set; }

	public string ConnectedFrequency { get; set; }

	public string OnInternet { get; set; }

	public string Ssid { get; set; }
}

public class WebOSWifiDirect
{
	public string State { get; set; }
}

public class WebOSWired
{
	public bool Plugged { get; set; }

	public string State { get; set; }
}
