using Microsoft.Extensions.Logging;

namespace GymScheduler.Core.Services.Logging;

public class LoggerService : ILoggerService {
    private readonly ILogger<LoggerService> _logger;

    public LoggerService(ILogger<LoggerService> logger) {
        _logger = logger;
    }

    public void LogInformation(string message) {
        _logger.LogInformation(message);
    }

    public void LogError(Exception exception, string message) {
        _logger.LogError(message);
    }
}