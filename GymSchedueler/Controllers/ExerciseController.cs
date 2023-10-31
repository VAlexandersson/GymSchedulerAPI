using GymSchedueler.Contracts.Exercise;
using GymSchedueler.Models;
using GymSchedueler.Services.Exercises;
using Microsoft.AspNetCore.Mvc;

namespace GymSchedueler.Controllers;

[ApiController]
[Route("[controller]")]

public class ExerciseController : ControllerBase {
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService) {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    public IActionResult CreateExercise(CreateExerciseRequest request) {
        var exercise = new Exercise(
            Guid.NewGuid(), 
            request.Name, 
            request.Description, 
            request.TargetArea, 
            request.Equipment, 
            request.Difficulty, 
            request.ImageUrl, 
            DateTime.Now
            );

        _exerciseService.CreateExercise(exercise);

        var response = new ExerciseResponse(
            exercise.Id,
            exercise.Name,
            exercise.Description,
            exercise.TargetArea,
            exercise.Equipment,
            exercise.Difficulty,
            exercise.ImageUrl,
            exercise.LastModified
            );

        return CreatedAtAction(
            actionName: nameof(GetExercise),
            routeValues: new { id = exercise.Id },
            value: response
            );

    }

    [HttpGet("{id:guid}")]
    public IActionResult GetExercise(Guid id) {
        Exercise exercise = _exerciseService.GetExercise(id);

        var response = new ExerciseResponse(
            exercise.Id,
            exercise.Name,
            exercise.Description,
            exercise.TargetArea,
            exercise.Equipment,
            exercise.Difficulty,
            exercise.ImageUrl,
            exercise.LastModified
            );

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertExercise(Guid id, UpsertExerciseRequest request) {
        var exercise = new Exercise(
            id,
            request.Name,
            request.Description,
            request.TargetArea,
            request.Equipment,
            request.Difficulty,
            request.ImageUrl,
            DateTime.Now
            );

        _exerciseService.UpsertExercise(exercise);


        // TODO: Return 201 if created, 204 if updated
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteExercise(Guid id) {
        _exerciseService.DeleteExercise(id);
        return NoContent();
    }




}

