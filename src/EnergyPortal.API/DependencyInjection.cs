using EnergyPortal.Application.Assets;
using EnergyPortal.Application.Sites;

namespace EnergyPortal.API;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddOpenApi();
		services.AddControllers();
		services.AddScoped<ISitesService, SitesService>();
		services.AddScoped<IAssetsService, AssetsService>();

		return services;
	}
}
