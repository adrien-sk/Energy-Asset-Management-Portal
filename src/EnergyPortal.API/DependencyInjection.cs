﻿namespace EnergyPortal.API;

public static class DependencyInjection
{
	public static IServiceCollection AddPresentation(this IServiceCollection services)
	{
		services.AddOpenApi();
		services.AddControllers();

		return services;
	}
}
