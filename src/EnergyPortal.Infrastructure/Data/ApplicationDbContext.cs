using EnergyPortal.Domain.Sites;
using Microsoft.EntityFrameworkCore;

namespace EnergyPortal.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{

	}

	public DbSet<Site> Sites { get; set; }
}
