using System.Globalization;
using pizza_project.FileService;

namespace pizza_project.project.Middlewares;

public class ActionLogMiddleware
{
    private readonly RequestDelegate _next;
    public ActionLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILog logService)
    {
        logService.WriteMessage(DateTime.Now);
        logService.WriteMessage(context.Request.Method);
        logService.WriteMessage(context.Request.Body);
        logService.WriteMessage(context.Request.Headers);
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
        logService.WriteMessage(DateTime.Now);
        logService.WriteMessage(context.Response.StatusCode);
        logService.WriteMessage(context.Response.Body);
    }

}