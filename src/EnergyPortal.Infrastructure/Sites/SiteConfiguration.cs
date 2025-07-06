using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Sites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnergyPortal.Infrastructure.Sites;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
	public void Configure(EntityTypeBuilder<Site> builder)
	{
		builder.HasKey(s => s.Id);

		builder.Property(s => s.Id)
			.IsRequired();

		builder.Property(s => s.CreatedAt)
			.IsRequired();

		builder.ComplexProperty(s => s.Location);

		builder.HasMany<Asset>()
			.WithOne()
			.HasForeignKey(a => a.SiteId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasIndex(s => s.Name)
			.HasDatabaseName("IX_Sites_Name");
	}
}