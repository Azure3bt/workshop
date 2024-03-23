using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;

namespace PostgresSample;

public class RedisCacheService
{
	private readonly IDistributedCache? _cache;
	private readonly IConnectionMultiplexer _connectionMultiplexer;

	public RedisCacheService(IDistributedCache cache, IConfiguration configuration)
	{
		_cache = cache;
		_connectionMultiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConn") ?? string.Empty);
	}

	public T? GetCachedData<T>(string key)
	{
		var jsonData = _cache?.GetString(key);
		if (jsonData == null)
			return default(T);
		return JsonSerializer.Deserialize<T>(jsonData);
	}

	public void SetCachedData<T>(string key, T data, TimeSpan cacheDuration)
	{
		var options = new DistributedCacheEntryOptions
		{
			AbsoluteExpirationRelativeToNow = cacheDuration
		};
		var jsonData = JsonSerializer.Serialize(data);
		_cache?.SetString(key, jsonData, options);
	}

	public async Task SetItemCached<T>(string key, T item)
	{
		var database = _connectionMultiplexer.GetDatabase();
		var redisKey = new RedisKey(key);
		var redisValue = new RedisValue(key);
		await database.HashSetAsync(redisKey, new []{ new HashEntry(redisValue, JsonSerializer.Serialize<T>(item)) });
	}
}