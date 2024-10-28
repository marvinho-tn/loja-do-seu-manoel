using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

public class MeasurableModel
{
    [JsonPropertyName("altura")] 
    public uint Height { get; set; } = 0;
    
    [JsonPropertyName("largura")]
    public uint Width { get; set; } = 0;
    
    [JsonPropertyName("comprimento")]
    public uint Length { get; set; } = 0;

    public Measurable ConvertToMeasurable()
    {
        return new Measurable
        {
            Height = Height,
            Length = Length,
            Width = Width
        };
    }
}