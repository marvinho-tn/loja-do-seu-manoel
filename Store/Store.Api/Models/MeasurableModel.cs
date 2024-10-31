using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

/// <summary>
/// Modelo de dimensionáveis.
/// </summary>
public class MeasurableModel
{
    /// <summary>
    /// Altura do objeto.
    /// </summary>
    [JsonPropertyName("altura")] 
    public uint Height { get; set; } = 0;
    
    /// <summary>
    /// Largura do objeto.
    /// </summary>
    [JsonPropertyName("largura")]
    public uint Width { get; set; } = 0;
    
    /// <summary>
    /// Comprimento do objeto.
    /// </summary>
    [JsonPropertyName("comprimento")]
    public uint Length { get; set; } = 0;

    /// <summary>
    /// Método de conversão para o domínio.
    /// </summary>
    /// <returns>Entidade do domínio.</returns>
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