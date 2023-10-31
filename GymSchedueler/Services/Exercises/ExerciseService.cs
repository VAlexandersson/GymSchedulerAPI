using GymSchedueler.Models;

namespace GymSchedueler.Services.Exercises;

public class ExerciseService : IExerciseService {
    private static readonly Dictionary<Guid, Exercise> _exercises = new();
    
    public void CreateExercise(Exercise exercise) {
        _exercises.Add(exercise.Id, exercise);
    }

    public void DeleteExercise(Guid id)
    {
        _exercises.Remove(id);
    }

    public Exercise GetExercise(Guid id) {
        return _exercises[id];
    }

    public void UpsertExercise(Exercise exercise)
    {
        _exercises[exercise.Id] = exercise;
    }
}