using System.Net;
using ErrorHandling.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ErrorHandling.Api.Extensions
{
    public static class ExceptionErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseNativeGlobalExceptionErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;
                    
                    // Log exception and/or run some other necessary code...

                    var errorResponse = new ErrorResponse();

                    if (exception is HttpErrorException httpErrorException)
                    {
                        errorResponse.StatusCode = httpErrorException.StatusCode;
                        errorResponse.Message = httpErrorException.Message;
                    }

                    context.Response.StatusCode = (int) errorResponse.StatusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorResponse.ToString());
                });
            });

            return app;
        }
    }
}