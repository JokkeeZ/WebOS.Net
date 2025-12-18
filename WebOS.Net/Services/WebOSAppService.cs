using WebOS.Net.Apps;

namespace WebOS.Net.Services;

/// <summary>
/// Interacts with application and related API calls on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSAppService(WebOSClient client)
{
	/// <summary>
	/// Retrieves a list of all installed apps on the webOS device asynchronously. Including the hidden ones.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="ListApps"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<ListApps> ListAppsAsync()
	{
		var response = await client.SendRequestAsync<ListAppsRequest, ListApps>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	/// <summary>
	/// Launches an application on the webOS device asynchronously.
	/// </summary>
	/// <param name="payload">The payload containing the application id to launch.</param>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="Launch"/>.</returns>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="payload"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown when the <see cref="LaunchRequestPayload.Id"/> is null or empty.</exception>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<Launch> LaunchAppAsync(LaunchRequestPayload payload)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(payload.Id));

		var response = await client.SendRequestAsync<LaunchRequest, Launch>(new()
		{
			Payload = payload
		}) ?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	/// <summary>
	/// Retrieves a list of all launch points (apps) available on the webOS device asynchronously.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="ListLaunchPoints"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<ListLaunchPoints> ListLaunchPointsAsync()
	{
		var response = await client.SendRequestAsync<ListLaunchPointsRequest, ListLaunchPoints>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	/// <summary>
	/// Retrieves information about the currently running application on the webOS device asynchronously.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="GetForegroundAppInfo"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetForegroundAppInfo> GetForegroundAppInfoAsync()
	{
		var response = await client.SendRequestAsync<GetForegroundAppInfoRequest, GetForegroundAppInfo>(new())
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> CloseAppAsync(string appId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(appId));

		var request = new CloseRequest();
		request.Payload.Id = appId;

		var response = await client.SendRequestAsync(request)
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}

	/// <summary>
	/// Gets the app state. App must be opened with current client, otherwise it will give <c>403 access denied</c>.
	/// </summary>
	/// <param name="appId"></param>
	/// <returns></returns>
	/// <exception cref="WebOSException"></exception>
	public async Task<GetAppState> GetAppStateAsync(string appId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(appId));

		var state = new GetAppStateRequest();
		state.Payload.Id = appId;

		var response = await client.SendRequestAsync<GetAppStateRequest, GetAppState>(state)
			?? throw new WebOSException("No response received from the device.");

		return response.Payload;
	}
}
