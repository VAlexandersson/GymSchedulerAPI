using System.Net;
using Microsoft.AspNetCore.Http;

namespace GymScheduler.Middleware;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;
    
    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context) {
        try {
           await _next(context);
        } catch (Exception exception) {
            
            _logger.LogError(exception, "An unhandled exception has occurred.");
            await HandleException(context, exception);
        }
    }

    private Task HandleException(HttpContext context, Exception exception) {
        context.Response.ContentType = "application/json";
        
        if (exception is KeyNotFoundException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return context.Response.WriteAsJsonAsync(
                new {
                    status = context.Response.StatusCode, 
                    message = "Resource not found"
                });
        }
        
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        var response = new {
            status = context.Response.StatusCode,
             message = "An internal server error occurred.",
             detailedMessage = exception.Message
        };
        return context.Response.WriteAsJsonAsync(response);
    }
    
}