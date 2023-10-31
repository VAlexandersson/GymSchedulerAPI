using GymSchedueler.Models;

namespace GymSchedueler.Services.Exercises;

public interface IExerciseService {
    void CreateExercise(Exercise exercise);
    void DeleteExercise(Guid id);
    Exercise GetExercise(Guid id);
    void UpsertExercise(Exercise exercise);
}