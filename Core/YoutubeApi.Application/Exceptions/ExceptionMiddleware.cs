using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace YoutubeApi.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await  HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(FluentValidation.ValidationException))
                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((FluentValidation.ValidationException)exception).Errors.Select(x => x.ErrorMessage).ToList(),
                    StatusCode = StatusCodes.Status400BadRequest
                }.ToString());

            List<string> errors = new List<string>
               {
                   exception.Message,
                   exception.InnerException?.ToString()
               };

            return httpContext.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode
            }.ToString());
        }

        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}
