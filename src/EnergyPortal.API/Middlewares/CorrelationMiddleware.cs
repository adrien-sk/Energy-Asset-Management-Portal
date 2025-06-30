using Serilog.Context;
using System.Diagnostics;

namespace EnergyPortal.API.Middlewares;

public class CorrelationMiddleware
{
	private readonly RequestDelegate _next;

	public CorrelationMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		var correlationId = GetOrCreateCorrelationId(context);

		context.Response.Headers.Append("X-Correlation-ID", correlationId);

		using (LogContext.PushProperty("CorrelationId", correlationId))
		using (LogContext.PushProperty("UserId", context.User.Identity?.Name ?? "anonymous"))
		using (LogContext.PushProperty("RequestPath", context.Request.Path.Value))
		using (LogContext.PushProperty("RequestMethod", context.Request.Method))
		using (LogContext.PushProperty("UserAgent", context.Request.Headers["User-Agent"].FirstOrDefault()))
		{
			await _next(context);
		}
	}

	private static string GetOrCreateCorrelationId(HttpContext context)
	{
		// Check if client provided correlation ID
		if (context.Request.Headers.TryGetValue("X-Correlation-ID", out var correlationId) &&
			!string.IsNullOrEmpty(correlationId))
		{
			return correlationId!;
		}

		// Use trace identifier or generate new GUID
		return Activity.Current?.Id ?? context.TraceIdentifier ?? Guid.NewGuid().ToString();
	}
}
