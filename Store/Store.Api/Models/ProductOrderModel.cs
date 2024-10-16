using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class ProductOrderModel
{
    [MinLength(0)]
    [JsonPropertyName("altura")]
    public int Height { get; set; }

    [MinLength(0)]
    [JsonPropertyName("largura")]
    public int Width { get; set; }

    [MinLength(0)]
    [JsonPropertyName("comprimento")]
    public int Length { get; set; }
}