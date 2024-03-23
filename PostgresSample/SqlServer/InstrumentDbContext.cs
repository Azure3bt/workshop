using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PostgresSample.SqlServer.Configuration;

namespace PostgresSample.SqlServer;

public class InstrumentDbContext : DbContext
{
	private readonly IConfiguration _configuration;
	public DbSet<Instrument> Instruments { get; set; }
	public DbSet<InstrumentUpdaterLog> InstrumentUpdaterLog { get; set; }

	public InstrumentDbContext(DbContextOptions<InstrumentDbContext> options, IConfiguration configuration) : base(options)
	{
		_configuration = configuration;
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnection"));
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("basicInfo.v2");
		modelBuilder.ApplyConfiguration(new InstrumentConfig());
		base.OnModelCreating(modelBuilder);
	}

	public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
	{
		var a = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
		foreach (var entry in a)
		{
			if (entry.State == EntityState.Added)
				if (entry.Entity.GetType().GetProperty("CreatedAt") != null)
					entry.Entity.GetType().GetProperty("CreatedAt").SetValue(entry.Entity, DateTime.Now);
			if (entry.State == EntityState.Modified)
				if (entry.Entity.GetType().GetProperty("UpdatedAt") != null)
					entry.Entity.GetType().GetProperty("UpdatedAt").SetValue(entry.Entity, DateTime.Now);
		}

		return await base.SaveChangesAsync(cancellationToken);
	}
}
