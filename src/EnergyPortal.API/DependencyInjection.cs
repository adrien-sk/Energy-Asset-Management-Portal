namespace EnergyPortal.API;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddCors(options =>
		{
			options.AddDefaultPolicy(
				policy =>
				{
					policy
					.WithOrigins(configuration["CorsConfig:AllowedOrigin"])
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials();
				});
		});

		services.AddOpenApi();
		services.AddControllers();

		return services;
	}
}
