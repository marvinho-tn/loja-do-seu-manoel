using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class MeasurableModel
{
    [Required]
    [MinLength(0)]
    [JsonPropertyName("altura")]
    public int Height { get; set; }

    [Required]
    [MinLength(0)]
    [JsonPropertyName("largura")]
    public int Width { get; set; }

    [Required]
    [MinLength(0)]
    [JsonPropertyName("comprimento")]
    public int Length { get; set; }
}