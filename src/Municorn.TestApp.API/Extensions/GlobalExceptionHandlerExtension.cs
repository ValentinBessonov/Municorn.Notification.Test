using Microsoft.AspNetCore.Diagnostics;
using Municorn.TestApp.Core;
using System.Net;

namespace Municorn.TestApp.Extensions;

public static class GlobalExceptionHandlerExtension
{
    public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
        => services.AddExceptionHandler(options =>
        {
            options.ExceptionHandler = (c) =>
            {
                var exception = c.Features.Get<IExceptionHandlerFeature>();

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
