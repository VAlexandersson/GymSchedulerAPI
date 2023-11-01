namespace GymScheduler.Contracts.Exercise;

public record ExerciseResponse(
    Guid Id,
    string Name,
    string Description,
    string TargetArea,
    string Equipment,
    string Difficulty,
    string ImageUrl,
    DateTime LastModified);
