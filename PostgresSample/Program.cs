using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PostgresSample.RabbitMq;
using StackExchange.Redis;

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


					serviceCollection.AddMassTransit(option => {

						option.UsingRabbitMq((ctx, cfg) => {

							cfg.Host("localhost", "/", h =>
							{
								h.Username("guest");
								h.Password("guest");
							});
							option.AddConsumer<UserConsumer>();
						});
					});
					serviceCollection.AddScoped<RedisCacheService>();
				});
			IHost host = builder.Build();


			using var dbContext = host.Services.GetRequiredService<DataContext>();
			var redisCacheService = host.Services.GetRequiredService<RedisCacheService>();
			foreach(var user in dbContext.Users)
			{
				redisCacheService.SetItemCached(user.Id.ToString(), user).GetAwaiter().GetResult();
			}
			host.Run();
		}
	}
}
