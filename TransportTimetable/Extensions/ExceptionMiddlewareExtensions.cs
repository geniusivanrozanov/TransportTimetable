using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace TransportTimetable.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var logger = context.RequestServices.GetService<ILogger<ExceptionHandlerMiddleware>>();

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    logger?.LogError("{Error}", contextFeature.Error);

                    await context.Response.WriteAsJsonAsync(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal server error"
                    });
                }
            });
        });
    }
}