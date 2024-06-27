namespace WebOS.Net.SampleApp;

class Program
{
	const string FilePath = "device.json";

	static async Task Main()
	{
		// Load device details from file if exists.
		var device = WebOSDevice.FromFileIfExists(FilePath);

		// If file did not exist, search device with uPnP M-SEARCH
		if (device == null)
		{
			try
			{
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

		Console.WriteLine(hello.ToString());

		if (!File.Exists(FilePath))
		{
			// Save device details to a file for future use.
			// Contains details such as IP-Address, port, MAC addresses and basic details about device.
			client.Device.SaveToFile(FilePath);
		}

		// Check if client is connected and paired
		if (client.IsActive)
		{
			var toast = await client.Notifications.ToastAsync("Hello from WebOS.Net!");

			if (toast.Payload.ReturnValue)
			{
				Console.WriteLine("Toast was sent successfully!");
			}
		}
	}
}
