using MassTransit;
using Microsoft.Extensions.Hosting;

namespace PostgresSample.RabbitMq;

public class UserProducer : BackgroundService
{
	private readonly IBus _eventBus;
	private readonly RedisCacheService _redisCacheService;
	public UserProducer(IBus eventBus, RedisCacheService redisCacheService)
	{
		_eventBus = eventBus;
		_redisCacheService = redisCacheService;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			foreach (var item in await _redisCacheService.GetAllItems<User>())
			{
				await _eventBus.Publish<User>(item);
				await Console.Out.WriteLineAsync($"Message with : {item.Id} has been published!");
				await Task.Delay(2000);
			}
		}
	}
}
