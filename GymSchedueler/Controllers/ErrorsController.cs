using Microsoft.AspNetCore.Mvc;

namespace GymSchedueler.Controllers;

public class ErrorsController : ControllerBase {
    [Route("/error")]

    public IActionResult Error() {
        return Problem();
    }
    
/*     public IActionResult Error() {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context.Error;

        var problemDetails = new ProblemDetails {
            Instance = context.HttpContext.Request.Path,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.StackTrace,
            Title = exception.Message,
            Type = $"https://httpstatuses.com/{StatusCodes.Status500InternalServerError}"
        };

        return StatusCode(StatusCodes.Status500InternalServerError, problemDetails);
    } */
}