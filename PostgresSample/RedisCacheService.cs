using MassTransit.Initializers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Text.Json;

namespace PostgresSample;

public class RedisCacheService
{
	private readonly IDistributedCache? _cache;
	private readonly IConnectionMultiplexer _connectionMultiplexer;
	private readonly string AllItems = nameof(AllItems);
	private readonly string NewAllItems = nameof(NewAllItems);

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

	public async Task SetItemCached<Tkey, T>(T item) where T : Entity<Tkey>
	{
		var database = _connectionMultiplexer.GetDatabase();
		await database.HashSetAsync(new RedisKey(NewAllItems), CreateHashEntries<Tkey, T>(new[] { item }).ToArray());
	}

	public async Task SetItemCached<Tkey, T>(T[] items) where T : Entity<Tkey>
	{
		var database = _connectionMultiplexer.GetDatabase();
		await database.HashSetAsync(new RedisKey(AllItems), CreateHashEntries<Tkey, T>(items).ToArray());
	}

	public async Task<IEnumerable<T>> GetAllItems<T>()
	{
		var database = _connectionMultiplexer.GetDatabase();
		return (await database.HashGetAllAsync(AllItems)).Select(item => JsonSerializer.Deserialize<T>(item.Value));
	}

	private IEnumerable<HashEntry> CreateHashEntries<Tkey, T>(IEnumerable<T> items) where T : Entity<Tkey>
	{
		foreach (var item in items)
			yield return new HashEntry(new RedisValue(item.Id.ToString()), JsonSerializer.Serialize<T>(item));
	}
}