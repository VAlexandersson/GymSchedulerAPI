namespace GymScheduler.Contracts.Exercise;

public record CreateExerciseRequest(
    string Name, 
    string Description,
    string TargetArea,
    string Equipment,
    string Difficulty,
    string ImageUrl);