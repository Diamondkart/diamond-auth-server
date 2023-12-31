using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiamondAuthServer.Domain.Exceptions
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static int GetStatusCode(Exception exception) =>
        exception switch
        {
            BadRequest => StatusCodes.Status400BadRequest,

            AuthenticationFailureException => StatusCodes.Status401Unauthorized,
            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
            ForbiddenException => StatusCodes.Status403Forbidden,
            NotFoundException => StatusCodes.Status404NotFound,
            ApplicationException => StatusCodes.Status500InternalServerError,
            CustomEvolveException => StatusCodes.Status500InternalServerError,
            NotImplementedException => StatusCodes.Status501NotImplemented,
            _ => StatusCodes.Status500InternalServerError
        };

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = GetStatusCode(exception);
            var errorResponse = new ErrorResponse { Message = exception.Message ?? $"Exception occured. exception={exception}" };
            var result = JsonSerializer.Serialize(new { errors = errorResponse });
            await context.Response.WriteAsync(result);
        }
    }
}