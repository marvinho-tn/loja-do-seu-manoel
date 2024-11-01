using System.Text.Json.Serialization;
using Store.Domain.Utils;

namespace Store.Api.Models;

public class ResultViewModel(object obj = null, IEnumerable<Validation> errors = null)
{
    [JsonPropertyName("objeto")] 
    public object Obj { get; set; } = obj;

    [JsonPropertyName("erros")] 
    public IEnumerable<Validation> Errors { get; set; } = errors;

    public static ResultViewModel CreateFromResult<T>(Result<T> result)
    {
        return new ResultViewModel(result.Obj, result.Errors);
    }
}