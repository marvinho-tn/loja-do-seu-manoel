using System.Net;
using Newtonsoft.Json;
using Store.Api.Models;
using Store.Domain.Utils;

namespace Store.Api.Middlewares;

public class ExceptionHandler(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new ResultViewModel(errors: new List<Validation>
            {
                new Validation(ValidationType.UnexpectedError)
            });
            
            var resultString = JsonConvert.SerializeObject(result);
            
            await context.Response.WriteAsync(resultString);

            throw;
        }
    }
}

public static class ExceptionHandlerExtensions
{
    public static IApplicationBuilder UseException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandler>();
    }
}