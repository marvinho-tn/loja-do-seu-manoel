using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class ProductOrderModel
{
    [JsonPropertyName("produto_id")]
    public string Id { get; set; }
    
    [JsonPropertyName("dimensoes")]
    public MeasurableModel Dimensions { get; set; }
}