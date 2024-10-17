using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class MeasurableModel
{
    [Required]
    [JsonPropertyName("altura")]
    public uint Height { get; set; }

    [Required]
    [JsonPropertyName("largura")]
    public uint Width { get; set; }

    [Required]
    [JsonPropertyName("comprimento")]
    public uint Length { get; set; }
}