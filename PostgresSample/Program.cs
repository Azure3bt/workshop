using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PostgresSample.RabbitMq;
using StackExchange.Redis;
using System.Reflection;

namespace PostgresSample
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var builder = Host.CreateDefaultBuilder()
				.ConfigureAppConfiguration(builder =>
				{
					builder.AddEnvironmentVariables()
					.AddCommandLine(args)
					.AddJsonFile("appsettings.json");
				})
				.ConfigureServices((hostBuilder, serviceCollection) =>
				{
					serviceCollection.AddDbContext<DataContext>(
						options =>
						{
							options.UseNpgsql();
						}
					);

					serviceCollection.AddStackExchangeRedisCache(options =>
					{
						options.Configuration = hostBuilder.Configuration.GetConnectionString("RedisConn");
						options.InstanceName = "GamesCatalog_";
					});


					serviceCollection.AddMassTransit(x =>
					{
						x.SetKebabCaseEndpointNameFormatter();

						// By default, sagas are in-memory, but should be changed to a durable
						// saga repository.
						x.SetInMemorySagaRepositoryProvider();

						var entryAssembly = Assembly.GetEntryAssembly();

						x.AddConsumers(entryAssembly);
						x.AddSagaStateMachines(entryAssembly);
						x.AddSagas(entryAssembly);
						x.AddActivities(entryAssembly);

						//x.UsingInMemory((context, cfg) =>
						//{
						//	cfg.ConfigureEndpoints(context);
						//});
						x.UsingRabbitMq((context, cfg) =>
						{
							cfg.Host("localhost", "/", h =>
							{
								h.Username("guest");
								h.Password("guest");
							});

							cfg.ConfigureEndpoints(context);
						});
					});
					serviceCollection.AddScoped<RedisCacheService>();
					serviceCollection.AddHostedService<UserProducer>();
				});
			IHost host = builder.Build();


			//using var dbContext = host.Services.GetRequiredService<DataContext>();
			//var redisCacheService = host.Services.GetRequiredService<RedisCacheService>();
			//redisCacheService.SetItemCached<int, User>([.. dbContext.Users]).GetAwaiter().GetResult();

			host.Run();
		}
	}
}
