namespace WebOS.Net.SampleApp;

class Program
{
	const string FilePath = "device.json";

	static async Task Main()
	{
		// Load device details from file if exists.
		var device = WebOSDevice.FromFileIfExists(FilePath);

		if (device == null)
		{
			try
			{
				// If file did not exist, search device with uPnP M-SEARCH
				device = await WebOSDevice.MSearchForDeviceAsync();
			}
			catch (WebOSException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}
		}


		// Initialize a new client to interact with webOS device.
		using var client = new WebOSClient(device);

		// Connect to device and start authentication process.
		var hello = await client.ConnectAsync();

		if (!File.Exists(FilePath))
		{
			// Save device details to a file for future use.
			// Contains details such as IP-Address, port, MAC addresses and basic details about device.
			client.Device.SaveToFile(FilePath);
		}

		// Check if client is connected and paired
		if (client.IsActive)
		{
			//await OpenSpotify(client);
			//await GetForegroundAppInfo(client);
			//await Toast(client);
			//await Alert(client);
			//await ListAllApps(client);
			//await ListAllLaunchPoints(client);
			//await CloseSpotify(client);
		}
	}

	static async Task GetForegroundAppInfo(WebOSClient c)
	{
		var info = await c.Apps.GetForegroundAppInfo();
		Console.WriteLine($"Foreground app id: {info.AppId}");
	}

	static async Task Toast(WebOSClient c)
	{
		await c.Notifications.ToastAsync("Hello :)");
	}

	static async Task Alert(WebOSClient c)
	{
		await c.Notifications.AlertAsync("Hello!",
		[
			new("Button 1"),
			new("Button 2")
		]);
	}

	static async Task OpenSpotify(WebOSClient c)
	{
		await c.Apps.LaunchAppAsync(new()
		{
			Id = "spotify-beehive"
		});
	}

	static async Task ListAllApps(WebOSClient c)
	{
		foreach (var app in await c.Apps.GetAllAsync())
		{
			Console.WriteLine($"App Title: {app.Title}");
		}
	}

	static async Task ListAllLaunchPoints(WebOSClient c)
	{
		foreach (var app in await c.Apps.GetAllLaunchPointsAsync())
		{
			Console.WriteLine($"App Title: {app.Title} | Removable: {app.Removable}");
		}
	}

	static async Task CloseSpotify(WebOSClient c)
	{
		await c.Apps.CloseAppAsync("spotify-beehive");
	}
}
