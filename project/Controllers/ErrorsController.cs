using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace pizza_project.project.Controllers;

//[Route("api/[controller]")]
[ApiController]
public class ErrorsController : ControllerBase
{
    ILogger<ErrorsController> logger;
    public ErrorsController(ILogger<ErrorsController> logger)
    {
        this.logger = logger;
    }

    [NonAction]
    [Route("/error")]
    public ActionResult Error([FromServices] IHostEnvironment hostEnvironment)
    {
        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>();
        logger.LogError(exceptionHandlerFeature?.Error.ToString());

        return Problem(
            detail: "Please try later...",
            title: "Sorry...");

    }
    [NonAction]
    [Route("/error-development")]
    public ActionResult DevelopmentError([FromServices] IHostEnvironment hostEnvironment)
    {
        if (!hostEnvironment.IsDevelopment())
        {
            return Error(hostEnvironment);
        }
        var exceptionHandlerFeature =
            HttpContext.Features.Get<IExceptionHandlerFeature>();
        logger.LogError(exceptionHandlerFeature?.Error.ToString());

        return Problem(
            detail: exceptionHandlerFeature.Error.StackTrace,
            title: exceptionHandlerFeature.Error.Message);

    }
}

