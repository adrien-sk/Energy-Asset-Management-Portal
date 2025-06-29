using EnergyPortal.Domain.Sites;
using EnergyPortal.Infrastructure.Data;
using EnergyPortal.Infrastructure.Sites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyPortal.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		});

		services.AddScoped<ISiteRepository, SiteRepository>();

		return services;
	}
}
