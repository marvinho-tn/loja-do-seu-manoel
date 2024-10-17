using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class MeasurableModel
{
    [JsonPropertyName("altura")]
    public uint Height { get; set; }
    
    [JsonPropertyName("largura")]
    public uint Width { get; set; }
    
    [JsonPropertyName("comprimento")]
    public uint Length { get; set; }
}