using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace PostgresSample.SqlServer.Configuration;
public class InstrumentConfig : IEntityTypeConfiguration<Instrument>
{
	public void Configure(EntityTypeBuilder<Instrument> entity)
	{
		entity.ToTable(nameof(Instrument));
		entity.HasKey(e => e.InstrumentId);
		entity.Property(e => e.InstrumentId);

		entity.Property(e => e.Name)
			.HasMaxLength(50)
			.IsRequired();
	}
}
