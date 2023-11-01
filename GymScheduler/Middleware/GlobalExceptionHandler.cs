using System.Net;

namespace GymScheduler.Middleware;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    private static readonly Dictionary<Type, (HttpStatusCode statusCode, string message)> ExceptionMappings = new() {
        { typeof(KeyNotFoundException), (HttpStatusCode.NotFound, "The specified item was not found.") },
        { typeof(ArgumentException), (HttpStatusCode.BadRequest, "Bad request.") },
    };
    
    public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger) {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context) {
        try {
           await _next(context);
        } catch (Exception exception) {
            _logger.LogInformation($"Handling exception. {exception.Message}");
            await HandleException(context, exception);
        }
    }

    private Task HandleException(HttpContext context, Exception exception) {
        context.Response.ContentType = "application/json";
        
        var (statusCode, message) = ExceptionMappings.GetValueOrDefault(exception.GetType(), 
            (HttpStatusCode.InternalServerError, "An internal server error occurred."));
        
        context.Response.StatusCode = (int)statusCode;
        
        return context.Response.WriteAsJsonAsync( new { 
                status = context.Response.StatusCode, 
                message, 
                detailedMessage = exception.Message
            });
    }
}