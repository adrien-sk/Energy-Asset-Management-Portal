using EnergyPortal.API;
using EnergyPortal.Application;
using EnergyPortal.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddPresentation()
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

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
