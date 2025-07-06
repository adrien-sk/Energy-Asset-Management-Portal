using EnergyPortal.API;
using EnergyPortal.API.Middlewares;
using EnergyPortal.Application;
using EnergyPortal.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services
	.AddPresentation(builder.Configuration)
	.AddApplication()
	.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("/openapi/v1.json", "Energy Portal API");
	});
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors();

app.Run();
