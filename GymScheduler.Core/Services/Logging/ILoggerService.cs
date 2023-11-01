namespace GymScheduler.Core.Services.Logging;

public interface ILoggerService
{
    void LogInformation(string message);
    void LogError(Exception exception, string message);
}