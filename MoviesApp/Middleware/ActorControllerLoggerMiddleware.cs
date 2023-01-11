using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MoviesApp.Middleware;

public class ActorControllerLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ActorControllerLoggerMiddleware> _logger;

    public ActorControllerLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
    {
        _next = next;
        _logger = loggerFactory.CreateLogger<ActorControllerLoggerMiddleware>();
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        if (httpContext.Request.Path.Value.ToLower().Contains("actor"))
        {
            _logger.LogDebug(
                $"Method: {httpContext.Request.Method}/n" +
                $"Path: {httpContext.Request.Path}/n" +
                $"Query: {string.Join(", ", from q in httpContext.Request.Query select $"{q.Key} = {string.Join(", ", q.Value)};")}\n");
        }
        await _next.Invoke(httpContext);
    }
}