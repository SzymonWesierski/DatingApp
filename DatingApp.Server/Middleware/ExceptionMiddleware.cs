﻿using DatingApp.Server.Errors;
using System.Net;
using System.Text.Json;

namespace DatingApp.Server.Middleware;

public class ExceptionMiddleware
{
	private readonly ILogger<ExceptionMiddleware> _logger;
	private readonly IHostEnvironment _env;
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger,
		IHostEnvironment env, RequestDelegate next)
	{
		_logger = logger;
		_env = env;
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, ex.Message);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = _env.IsDevelopment()
				? new ApiExceptions(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
				: new ApiExceptions(context.Response.StatusCode, ex.Message, "Internal Server Error");

			var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

			var json = JsonSerializer.Serialize(response, options);

			await context.Response.WriteAsync(json);
		}
	}
}
