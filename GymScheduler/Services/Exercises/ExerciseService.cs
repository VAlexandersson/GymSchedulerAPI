//using GymScheduler.Core.Services.Logging;
using GymScheduler.Models;

namespace GymScheduler.Services.Exercises;

public class ExerciseService : IExerciseService {
    private static readonly Dictionary<Guid, Exercise> _exercises = new();
    private readonly ILogger<ExerciseService> _logger;
    
    public ExerciseService(ILogger<ExerciseService> logger) {
         _logger = logger;
    }
    
    public void CreateExercise(Exercise exercise) {
        _logger.LogInformation($"Exercise {exercise.Id} created.");
        _exercises.Add(exercise.Id, exercise);
    }

    public void DeleteExercise(Guid id) {
        _exercises.Remove(id);
       // _loggerService.LogInformation($"Exercise {id} deleted.");
    }

    public Exercise GetExercise(Guid id) {
            if(_exercises.TryGetValue(id, out var exercise))
                return exercise;
            throw new KeyNotFoundException($"Exercise {id} not found.");
    }

    public void UpsertExercise(Exercise exercise) {
        _exercises[exercise.Id] = exercise;
       // _loggerService.LogInformation($"Exercise {exercise.Id} upserted.");
    }
}