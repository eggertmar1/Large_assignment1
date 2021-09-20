using Microsoft.AspNetCore.Builder;
using System;
using TechnicalRadiation.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.WebApi.ExceptionHandlerExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => {
                error.Run(async context => {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>(); //Gets the current exception
                    if (exceptionHandlerFeature != null) {
                        var exception = exceptionHandlerFeature.Error;
                        var statusCode = (int) HttpStatusCode.InternalServerError; //Default status code error

                        if (exception is ModelFormatException) {
                            statusCode = (int) HttpStatusCode.PreconditionFailed;
                        }
                        else if (exception is ArgumentOutOfRangeException) {
                            statusCode = (int) HttpStatusCode.BadRequest;
                        }

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = statusCode;

                        var response = new ExceptionModel {
                            StatusCode = statusCode,
                            ExceptionMessage = exception.Message,
                            StackTrace = exception.StackTrace
                        };

                        response.StackTrace = null;
                        await context.Response.WriteAsync(response.ToString());
                    }
                });
            });
        }
    }
}