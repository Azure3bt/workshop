using MassTransit;

namespace PostgresSample.RabbitMq;

public class UserConsumer : IConsumer<User>
{
	private readonly IBus _eventBus;

	public UserConsumer(IBus eventBus)
	{
		_eventBus = eventBus;
	}

	public async Task Consume(ConsumeContext<User> context)
	{
		await _eventBus.Publish(context.Message);
	}
}
