using GymScheduler.Models;

namespace GymScheduler.Services.Exercises;

public class ExerciseService : IExerciseService {
    private static readonly Dictionary<Guid, Exercise> _exercises = new();
    private readonly ILogger<ExerciseService> _logger;
    
    public ExerciseService(ILogger<ExerciseService> logger) {
         _logger = logger;
    }
    
    public void CreateExercise(Exercise exercise) {
        if (_exercises.ContainsKey(exercise.Id))
            throw new ArgumentException($"Creation failed. Exercise {exercise.Id} already exists.");
        if (_exercises.Values.Any(e => e.Name == exercise.Name))
            throw new ArgumentException($"Creation failed. Exercise {exercise.Name} already exists.");
        _exercises.Add(exercise.Id, exercise);
        _logger.LogInformation($"Exercise {exercise.Id} created.");
    }

    public void DeleteExercise(Guid id) {
        if(!_exercises.Remove(id))
            throw new KeyNotFoundException($"Delete failed. Exercise {id} not found.");
        _logger.LogInformation($"Exercise {id} deleted.");
    }

    public Exercise GetExercise(Guid id) {
            if(_exercises.TryGetValue(id, out var exercise))
                return exercise;
            throw new KeyNotFoundException($"Exercise {id} not found.");
    }

    public void UpsertExercise(Exercise exercise) {
        _exercises[exercise.Id] = exercise;
        _logger.LogInformation($"Exercise {exercise.Id} upserted.");
    }
}