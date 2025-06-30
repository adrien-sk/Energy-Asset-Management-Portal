using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace EnergyPortal.API.Middlewares;

public class GlobalExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<GlobalExceptionMiddleware> _logger;

	public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext context, Exception ex)
	{
		var (statusCode, errorResponse) = MapException(ex);
		LogException(ex, context, statusCode);

		context.Response.StatusCode = statusCode;
		context.Response.ContentType = "application/json";

		await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
	}

	private (int statusCode, object errorResponse) MapException(Exception ex)
	{
		return ex switch
		{
			//		Domain exceptions
			// AssetNotFoundException => (404, new { error = "Asset not found", message = ex.Message }),
			// SiteNotFoundException => (404, new { error = "Site not found", message = ex.Message }),
			// InvalidAssetOperationException => (400, new { error = "Invalid operation", message = ex.Message }),
			// CapacityExceededException => (400, new { error = "Capacity exceeded", message = ex.Message }),
			// BusinessRuleViolationException brv => (400, new { error = "Business rule violation", rule = brv.RuleName, message = ex.Message }),

			// Application exceptions
			ValidationException => (400, new { error = "Validation failed", message = ex.Message }),
			UnauthorizedAccessException => (401, new { error = "Unauthorized", message = "Access denied" }),

			// Infrastructure exceptions
			DbUpdateException => (500, new { error = "Database error", message = "A database error occurred" }),
			TimeoutException => (408, new { error = "Timeout", message = "The operation timed out" }),

			// Generic fallback
			_ => (500, new { error = "Internal server error", message = ex.Message })
		};
	}

	private void LogException(Exception ex, HttpContext context, int statusCode)
	{
		var logLevel = statusCode switch
		{
			>= 400 and < 500 => LogLevel.Warning,  // Client errors
			>= 500 => LogLevel.Error,              // Server errors
			_ => LogLevel.Information
		};

		_logger.Log(logLevel, ex,
			"Request {RequestMethod} {RequestPath} failed with {ExceptionType}: {ExceptionMessage}",
			context.Request.Method,
			context.Request.Path,
			ex.GetType().Name,
			ex.Message);
	}
}
