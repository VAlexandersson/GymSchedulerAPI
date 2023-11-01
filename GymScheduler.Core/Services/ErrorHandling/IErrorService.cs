using GymScheduler.Core.Models;

namespace GymScheduler.Core.Services.ErrorHandling;

public interface IErrorService
{
    ErrorResponse HandleException(Exception exception);
}
