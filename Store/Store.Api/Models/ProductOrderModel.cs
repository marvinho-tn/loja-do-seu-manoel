using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

/// <summary>
/// Modelo de Produto.
/// </summary>
public class ProductOrderModel
{
    /// <summary>
    /// Identificação do produto.
    /// </summary>
    [JsonPropertyName("produto_id")]
    public string Id { get; set; } = null!;
    
    /// <summary>
    /// Dimensões do produto.
    /// </summary>
    [JsonPropertyName("dimensoes")]
    public MeasurableModel Dimensions { get; set; }

    /// <summary>
    /// Método de conversão para o domínio
    /// </summary>
    /// <returns>Entidade de domínio.</returns>
    public Product ConvertToProduct()
    {
        return new Product
        {
            Id = Id,
            Dimensions = Dimensions.ConvertToMeasurable()
        };
    }
}