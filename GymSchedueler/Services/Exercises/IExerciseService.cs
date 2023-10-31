using GymSchedueler.Models;

namespace GymSchedueler.Services.Exercises;

public interface IExerciseService {
    void CreateExercise(Exercise exercise);
    Exercise GetExercise(Guid id);
}