namespace PostgresSample;

using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DataContext : DbContext
{
	protected readonly IConfiguration Configuration;

	public DataContext(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		// connect to postgres with connection string from app settings
		options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		var faker = new Faker();
		var moqUsers = new List<User>();

		for (int i = 0; i < 10_000; i++)
		{
			moqUsers.Add(new User()
			{
				Id = faker.Random.Int(),
				Username = faker.Random.Utf16String(),
				Password = faker.Random.Utf16String()
			});
		}

		modelBuilder.Entity<User>().HasData(moqUsers);
	}

	public DbSet<User> Users { get; set; }
}