using System.Net;
using Newtonsoft.Json;
using Store.Api.Models;
using Store.Domain.Utils;

namespace Store.Api.Middlewares;

/// <summary>
/// Classe de configuração do handler de excessões.
/// </summary>
public class ExceptionHandler(RequestDelegate next)
{
    /// <summary>
    /// Método de processamento da excessão.
    /// </summary>
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

/// <summary>
/// Classe de configuração da excessão na API.
/// </summary>
public static class ExceptionHandlerExtensions
{
    /// <summary>
    /// Método de configuração do handler.
    /// </summary>
    public static IApplicationBuilder UseException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandler>();
    }
}