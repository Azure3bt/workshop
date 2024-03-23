using MassTransit;

namespace PostgresSample.RabbitMq;

public class UserProducer
{
	private readonly IBus _eventBus;
	private readonly RedisCacheService _redisCacheService;
	public UserProducer(IBus eventBus, RedisCacheService redisCacheService)
	{
		_eventBus = eventBus;
		_redisCacheService = redisCacheService;
	}

	public async Task Produce(User user)
	{
		await _eventBus.Publish(user);
	}

	public async Task ProduceAllItems()
	{
		foreach (var item in await _redisCacheService.GetAllItems<User>())
		{
			await _eventBus.Publish<User>(item);
			await Task.Delay(20_000);
		}
	}
}
