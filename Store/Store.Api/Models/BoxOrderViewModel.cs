using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class BoxOrderViewModel
{
    [JsonPropertyName("caixa_id")]
    public string Id { get; set; }
    
    [JsonPropertyName("produtos")]
    public List<string> Products { get; set; }
}