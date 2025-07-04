using EnergyPortal.Application.Assets;

namespace EnergyPortal.API;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddOpenApi();
		services.AddControllers();
		services.AddScoped<IAssetsService, AssetsService>();

		return services;
	}
}
