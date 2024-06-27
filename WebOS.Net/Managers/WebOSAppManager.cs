using WebOS.Net.Apps;

namespace WebOS.Net.Managers;

/// <summary>
/// Manages applications on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="client">The webOS client used to communicate with the device.</param>
public class WebOSAppManager(WebOSClient client)
{
	/// <summary>
	/// Retrieves a list of all installed apps on the webOS device asynchronously. Including the hidden ones.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="WebOSApp"/>.</returns>
	public async Task<List<WebOSApp>> GetAllAsync()
	{
		var response = await client.SendRequestAsync<ListAppsRequest, ListAppsResponse, ListAppsResponsePayload>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload.Apps;
	}

	/// <summary>
	/// Launches an application on the webOS device asynchronously.
	/// </summary>
	/// <param name="payload">The payload containing the application ID to launch.</param>
	/// <returns>
	/// A task that represents the asynchronous operation.
	/// The task result contains the response from the launch operation.
	/// </returns>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="payload"/> is null.</exception>
	/// <exception cref="WebOSException">Thrown when the payload is null or the application ID is empty.</exception>
	public async Task<LaunchAppResponse> LaunchAppAsync(LaunchAppPayload payload)
	{
		if (payload == null)
		{
			ArgumentNullException.ThrowIfNull(nameof(payload));
		}

		if (string.IsNullOrEmpty(payload?.Id))
		{
			throw new WebOSException("AppId cannot be empty!");
		}

		var response = await client.SendRequestAsync<LaunchAppRequest, LaunchAppResponse, LaunchAppResponsePayload>(new()
		{
			Payload = payload
		});

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response;
	}

	/// <summary>
	/// Retrieves a list of all launch points (apps) available on the webOS device asynchronously.
	/// </summary>
	/// <returns>
	/// A task that represents the asynchronous operation. The task result contains a list of <see cref="LaunchPoint"/>.
	/// </returns>
	public async Task<List<LaunchPoint>> GetAllLaunchPointsAsync()
	{
		var response = await client
			.SendRequestAsync<ListLaunchPointsRequest, ListLaunchPointsResponse, ListLaunchPointsPayload>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload.LaunchPoints;
	}

	/// <summary>
	/// Retrieves information about the currently running application on the webOS device asynchronously.
	/// </summary>
	/// <returns>
	/// A task that represents the asynchronous operation. 
	/// The task result contains the payload with information about the foreground application.
	/// </returns>
	/// <exception cref="WebOSException">Thrown when the request to get foreground app information fails.</exception>
	public async Task<GetForegroundAppInfoPayload> GetForegroundAppInfo()
	{
		var response = await client
			.SendRequestAsync<GetForegroundAppInfoRequest, GetForegroundAppInfoResponse, GetForegroundAppInfoPayload>(new());

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
	/// <returns>
	/// A task that represents the asynchronous operation. 
	/// The task result contains a boolean value indicating whether the application was successfully closed.
	/// </returns>
	/// <exception cref="ArgumentNullException">Thrown when the <paramref name="appId"/> is null or empty.</exception>
	/// <exception cref="WebOSException">Thrown when the request to close the application fails.</exception>
	public async Task<bool> CloseAppAsync(string appId)
	{
		if (string.IsNullOrEmpty(appId))
		{
			ArgumentNullException.ThrowIfNull(nameof(appId));
		}

		var request = new CloseAppRequest();
		request.Payload.Id = appId;

		var response = await client
		.SendRequestAsync<CloseAppRequest, CloseAppResponse, CloseAppResponsePayload>(request);

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload.ReturnValue;
	}
}
