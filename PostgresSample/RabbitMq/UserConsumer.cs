using MassTransit;

namespace PostgresSample.RabbitMq;

public class UserConsumer : IConsumer<User>
{
	private readonly RedisCacheService _redisCacheService;

	public UserConsumer(RedisCacheService redisCacheService)
	{
		_redisCacheService = redisCacheService;
	}

	public async Task Consume(ConsumeContext<User> context)
	{
		await Console.Out.WriteLineAsync($"Message with : {context.Message.Id} has been consumed!");
		await _redisCacheService.SetItemCached<int, User>(context.Message);
	}
}
