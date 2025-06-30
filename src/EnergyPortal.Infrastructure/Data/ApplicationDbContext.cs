using EnergyPortal.Domain.Assets;
using EnergyPortal.Domain.Sites;
using EnergyPortal.Infrastructure.Assets;
using EnergyPortal.Infrastructure.Sites;
using Microsoft.EntityFrameworkCore;

namespace EnergyPortal.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options) { }

	public DbSet<Site> Sites { get; set; }
	public DbSet<Asset> Assets { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new SiteConfiguration());
		modelBuilder.ApplyConfiguration(new AssetConfiguration());
	}
}
