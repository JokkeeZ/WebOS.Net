using WebOS.Net.Apps;

namespace WebOS.Net.Managers;

/// <summary>
/// Manages applications on a webOS device through the provided <see cref="WebOSClient"/>.
/// </summary>
/// <param name="webOS">The webOS client used to communicate with the device.</param>
public class WebOSAppManager(WebOSClient webOS)
{
	/// <summary>
	/// Retrieves a list of all installed apps on the webOS device asynchronously. Including the hidden ones.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="WebOSApp"/>.</returns>
	public async Task<List<WebOSApp>> GetAllAsync()
	{
		var response = await webOS.SendRequestAsync<ListAppsRequest, ListAppsResponse, ListAppsResponsePayload>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue || response.Error != null)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload.Apps;
	}

	/// <summary>
	/// Launches an application on the webOS device asynchronously.
	/// </summary>
	/// <param name="payload">The payload containing the application ID to launch.</param>
	/// <returns>A task that represents the asynchronous operation. The task result contains the response from the launch operation.</returns>
	/// <exception cref="WebOSException">Thrown when the payload is null or the application ID is empty.</exception>
	public async Task<LaunchAppResponse> LaunchAppAsync(LaunchAppPayload payload)
	{
		if (payload == null)
		{
			throw new WebOSException("[LaunchApp] Payload cannot be null!");
		}

		if (string.IsNullOrEmpty(payload?.Id))
		{
			throw new WebOSException("[LaunchApp] AppId cannot be empty!");
		}

		var response = await webOS.SendRequestAsync<LaunchAppRequest, LaunchAppResponse, LaunchAppResponsePayload>(new()
		{
			Payload = payload
		});

		return response;
	}

	/// <summary>
	/// Retrieves a list of all launch points (apps) available on the webOS device asynchronously.
	/// </summary>
	/// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="LaunchPoint"/>.</returns>
	public async Task<List<LaunchPoint>> GetAllLaunchPointsAsync()
	{
		var response = await webOS
			.SendRequestAsync<ListLaunchPointsRequest, ListLaunchPointsResponse, ListLaunchPointsPayload>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue || response.Error != null)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload.LaunchPoints;
	}
}
