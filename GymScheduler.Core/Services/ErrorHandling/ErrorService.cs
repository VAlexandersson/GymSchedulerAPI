using GymScheduler.Core.Models;
using GymScheduler.Core.Services.Logging;

namespace GymScheduler.Core.Services.ErrorHandling;

public class ErrorService : IErrorService {
    private readonly ILoggerService _logger;

    public ErrorService(ILoggerService logger) {
        _logger = logger;
    }

    public ErrorResponse HandleException(Exception exception) {
        _logger.LogError(exception, exception.Message);
        return new ErrorResponse {
            ErrorCode = 500,
            ErrorMessage = "An error occurred while processing your request.",
            Details = exception.Message
        };
    }

}