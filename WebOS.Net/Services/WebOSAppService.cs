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
		var response = await client.SendRequestAsync<ListAppsRequest, ListAppsResponse, ListApps>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

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
		ArgumentNullException.ThrowIfNull(nameof(payload));
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(payload.Id));

		var response = await client.SendRequestAsync<LaunchRequest, LaunchResponse, Launch>(new()
		{
			Payload = payload
		});

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Retrieves a list of all launch points (apps) available on the webOS device asynchronously.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="ListLaunchPoints"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<ListLaunchPoints> ListLaunchPointsAsync()
	{
		var response = await client
			.SendRequestAsync<ListLaunchPointsRequest, ListLaunchPointsResponse, ListLaunchPoints>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Retrieves information about the currently running application on the webOS device asynchronously.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="GetForegroundAppInfo"/>.</returns>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetForegroundAppInfo> GetForegroundAppInfoAsync()
	{
		var response = await client
			.SendRequestAsync<GetForegroundAppInfoRequest, GetForegroundAppInfoResponse, GetForegroundAppInfo>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	/// <summary>
	/// Closes an application on the webOS device asynchronously.
	/// </summary>
	/// <param name="appId">The ID of the application to close.</param>
	/// <returns>A task that represents the asynchronous operation. The task result is <see cref="Close"/>.</returns>
	/// <exception cref="ArgumentException">Thrown when the <paramref name="appId"/> is null or empty.</exception>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<Close> CloseAppAsync(string appId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(appId));

		var request = new CloseRequest();
		request.Payload.Id = appId;

		var response = await client
			.SendRequestAsync<CloseRequest, CloseResponse, Close>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	private async Task<string> GetAppStatusAsync(string appId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(appId));

		var response = await client.SendRequestWithJsonResponseAsync<GetAppStatusRequest>(new()
		{
			Payload = new()
			{
				Id = appId
			}
		});

		return response;
	}

	/// <summary>
	/// Gets the state of the application. (is it running and/or visible)
	/// </summary>
	/// <remarks>
	/// **THIS ONLY WORKS IF THE APP WAS OPENED WITH THE CURRENT CLIENT.**
	/// </remarks>
	/// <param name="appId">The ID of the application to get state from.</param>
	/// <returns></returns>
	/// <exception cref="ArgumentException">Thrown when the <paramref name="appId"/> is null or empty.</exception>
	/// <exception cref="WebOSException">Thrown when the request fails, or contains an error.</exception>
	public async Task<GetAppState> GetAppStateAsync(string appId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(appId));

		var state = new GetAppStateRequest();
		state.Payload.Id = appId;

		var response = await client
			.SendRequestAsync<GetAppStateRequest, GetAppStateResponse, GetAppState>(state);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
