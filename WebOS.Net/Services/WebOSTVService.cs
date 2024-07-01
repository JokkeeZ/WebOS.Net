using WebOS.Net.TV;

namespace WebOS.Net.Services;

public class WebOSTVService(WebOSClient client)
{
	public async Task<GetChannelList> GetChannelListAsync()
	{
		var response = await client
			.SendRequestAsync<GetChannelListRequest, GetChannelListResponse, GetChannelList>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetChannelProgramInfo> GetChannelProgramInfoAsync()
	{
		var response = await client
			.SendRequestAsync<GetChannelProgramInfoRequest, GetChannelProgramInfoResponse, GetChannelProgramInfo>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetCurrentChannel> GetCurrentChannelAsync()
	{
		var response = await client
			.SendRequestAsync<GetCurrentChannelRequest, GetCurrentChannelResponse, GetCurrentChannel>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> ChannelUpAsync()
	{
		var response = await client
			.SendRequestAsync<ChannelUpRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> ChannelDownAsync()
	{
		var response = await client.SendRequestAsync<ChannelDownRequest>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> OpenChannelAsync(string channelNumber)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(channelNumber));

		var request = new OpenChannelRequest();
		request.Payload.ChannelNumber = channelNumber;

		var response = await client.SendRequestAsync<OpenChannelRequest>(request);

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetExternalInputList> GetExternalInputListAsync()
	{
		var response = await client
			.SendRequestAsync<GetExternalInputListRequest, GetExternalInputListResponse, GetExternalInputList>(new());

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<WebOSResponsePayload> SwitchInputAsync(string inputId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(nameof(inputId));

		var request = new SwitchInputRequest();
		request.Payload.InputId = inputId;

		var response = await client.SendRequestAsync<SwitchInputRequest>(request);

		if (response.Type != "response" || !response.Payload.ReturnValue)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
