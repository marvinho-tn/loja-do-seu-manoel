using System.Text.Json.Serialization;
using Store.Domain.Utils;

namespace Store.Api.Models;

/// <summary>
/// View de resultado da API
/// </summary>
/// <param name="obj">Objeto que vai expressar o resultado.</param>
/// <param name="errors">Possíveis erros.</param>
public class ResultViewModel(object? obj = null, IEnumerable<Validation>? errors = null)
{
    /// <summary>
    /// Objeto do resultado.
    /// </summary>
    [JsonPropertyName("objeto")] 
    public object? Obj { get; set; } = obj;

    /// <summary>
    /// Erros do negócio.
    /// </summary>
    [JsonPropertyName("erros")] 
    public IEnumerable<ValidationViewModel>? Errors { get; set; } = errors?.Select(error => new ValidationViewModel(error));

    /// <summary>
    /// Método de construção da classe a partir do resultado da aplicação.
    /// </summary>
    /// <param name="result">Objeto do resultado.</param>
    /// <typeparam name="T">Tipo de resultado.</typeparam>
    /// <returns>Instância da view.</returns>
    public static ResultViewModel CreateFromResult<T>(Result<T> result)
    {
        return new ResultViewModel(result.Obj, result.Errors);
    }
}

/// <summary>
/// View de validação
/// </summary>
/// <param name="validation">Validação da aplicação</param>
public class ValidationViewModel(Validation validation)
{
    /// <summary>
    /// Tipo da validação.
    /// </summary>
    [JsonPropertyName("codigo")] 
    public ValidationType Type { get; set; } = validation.Type;
}