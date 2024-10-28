using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

public class ProductOrderModel
{
    [JsonPropertyName("produto_id")]
    public string Id { get; set; } = null!;
    
    [JsonPropertyName("dimensoes")]
    public MeasurableModel Dimensions { get; set; }

    public Product ConvertToProduct()
    {
        return new Product
        {
            Id = Id,
            Dimensions = Dimensions.ConvertToMeasurable()
        };
    }
}