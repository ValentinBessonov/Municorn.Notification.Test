using Microsoft.AspNetCore.Diagnostics;
using Municorn.TestApp.Core;
using System.Net;
using System.Text.Json;

public static class GlobalExceptionHandler
{
    public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        => services.AddExceptionHandler(options =>
        {
            options.ExceptionHandler = (c) =>
            {
                var exception = c.Features.Get<IExceptionHandlerFeature>();

                var temp = exception.Error.GetType().ToString();

                var statusCode = exception.Error switch
                {
                    ElementNotFoundException => HttpStatusCode.NotFound,
                    ArgumentException => HttpStatusCode.BadRequest,
                    _ => HttpStatusCode.InternalServerError
                };

                c.Response.StatusCode = (int)statusCode;
                c.Response.WriteAsJsonAsync(new
                {
                    Message = "Something went wrong.",
                    Exception = exception.Error.Message
                }).GetAwaiter().GetResult();

                return Task.CompletedTask;
            };
        });
}
