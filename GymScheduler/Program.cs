using GymScheduler.Middleware;
using GymScheduler.Services.Exercises;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddLogging();

    builder.Services.AddScoped<IExerciseService, ExerciseService>();
    //builder.Services.AddSingleton<IErrorService, ErrorService>();
    //builder.Services.AddSingleton<ILoggerService, LoggerService>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    //app.UseExceptionHandler("/error");
    app.UseMiddleware<GlobalExceptionHandler>();
    app.MapControllers();
    app.Run();
}