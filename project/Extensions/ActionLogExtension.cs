using pizza_project.project.Middlewares;

namespace pizza_project.project.Extensions;

public static class ActionLogbMiddlewareExtension
{
    public static IApplicationBuilder UseActionLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActionLogMiddleware>();
    }
}