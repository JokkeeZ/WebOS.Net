# WebOS.Net
 Small async library for interacting with webOS TV through Secure WebSocket.

# Developed with
- [LG] webOS TV 55UR781C0LK
	- deviceOSVersion: `4.1.0`

# Example usage
## Sending notification toast to the TV
```c#
using var client = new WebOSClient(
	// WebOS TV IPv4 address
	ipAddress: "192.168.0.11",

	// Port 3001 for wss.
	port: 3001,

	// Provide a client-key or leave empty to obtain a client-key.
	clientKey: string.Empty
);

// The TV will display a prompt if a client-key is not provided.
await client.ConnectAsync();

if (client.IsPaired)
{
	Console.WriteLine($"Client Key: {client.ClientKey}");

	// Send Toast notification to webOS TV
	await client.Notifications.CreateToastAsync("Hello! :)");
}
```
## M-SEARCH for TV IP-Address
```c#
IPEndPoint endPoint;

try
{
    // Assuming the TV is on and connected to same network.
    endPoint = await WebOSDeviceLocator.MSearchForDeviceAsync();
}
catch (WebOSException ex)
{
    Console.WriteLine(ex.Message);
    return;
}

var clientKey = "ym4uui9suqq0xfntpuu9uzrwj67pyxig";
using var client = new WebOSClient(endPoint, clientKey);

await client.ConnectAsync();

if (client.IsPaired)
{
    var info = await client.ConnectionManager.GetInfoAsync();

    // Get WiFi or wired MAC address so TV can be opened with Wake-On-Lan.
    Console.WriteLine($"WiFi MAC Address: {info.WifiInfo.MacAddress}");
    Console.WriteLine($"Wired MAC Address: {info.WiredInfo.MacAddress}");
}
```
## Start TV with Wake-On-Lan
```c#
var macAddress = "AA:BB:CC:DD:EE:FF";
await WebOSDeviceLocator.SendWakeOnLanAsync(PhysicalAddress.Parse(macAddress));

// Give TV some time to startup.
await Task.Delay(5000);

IPEndPoint endPoint;

try
{
	// Assuming the TV is now on.
	endPoint = await WebOSDeviceLocator.MSearchForDeviceAsync();
}
catch (WebOSException ex)
{
	Console.WriteLine(ex.Message);
	return;
}

var clientKey = "ym4uui9suqq0xfntpuu9uzrwj67pyxig";
using var client = new WebOSClient(endPoint, clientKey);

await client.ConnectAsync();

if (client.IsPaired)
{
	await client.Notifications.CreateToastAsync("Hello :)");
}
```
