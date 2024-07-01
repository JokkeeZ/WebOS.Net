using WebOS.Net.TV;

namespace WebOS.Net.Services;

public class WebOSTVService(WebOSClient client)
{
	public async Task<GetChannelList> GetChannelListAsync()
	{
		var response = await client
			.SendRequestAsync<GetChannelListRequest, GetChannelListResponse, GetChannelList>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetChannelProgramInfo> GetChannelProgramInfoAsync()
	{
		var response = await client
			.SendRequestAsync<GetChannelProgramInfoRequest, GetChannelProgramInfoResponse, GetChannelProgramInfo>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<GetCurrentChannel> GetCurrentChannelAsync()
	{
		var response = await client
			.SendRequestAsync<GetCurrentChannelRequest, GetCurrentChannelResponse, GetCurrentChannel>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<ChannelUp> ChannelUpAsync()
	{
		var response = await client
			.SendRequestAsync<ChannelUpRequest, ChannelUpResponse, ChannelUp>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}

	public async Task<ChannelDown> ChannelDownAsync()
	{
		var response = await client
			.SendRequestAsync<ChannelDownRequest, ChannelDownResponse, ChannelDown>(new());

		if (!response.RequestSucceed)
		{
			throw new WebOSException(response.Error);
		}

		return response.Payload;
	}
}
