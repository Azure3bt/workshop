﻿using MassTransit;

namespace PostgresSample.RabbitMq;
public class UserConsumerDefinition :
	ConsumerDefinition<UserConsumer>
{
	protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<UserConsumer> consumerConfigurator)
	{
		endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));
	}
}