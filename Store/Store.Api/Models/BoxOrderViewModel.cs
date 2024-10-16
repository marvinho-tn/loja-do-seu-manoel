using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class BoxOrderViewModel : MeasurableModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("produtos")]
    public List<ProductOrderViewModel> Products { get; set; }
}