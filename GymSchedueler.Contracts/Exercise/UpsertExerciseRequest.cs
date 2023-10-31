namespace GymSchedueler.Contracts.Exercise;

public record UpsertExerciseRequest(
    string Name, 
    string Description,
    string TargetArea,
    string Equipment,
    string Difficulty,
    string ImageUrl);
