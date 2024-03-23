using MassTransit;

namespace PostgresSample.RabbitMq;

public class UserProducer
{
	private readonly IBus _eventBus;

	public UserProducer(IBus eventBus)
	{
		_eventBus = eventBus;
	}

	public async Task Produce(User user)
	{
		await _eventBus.Publish(user);
	}
}
