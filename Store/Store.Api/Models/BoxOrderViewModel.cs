using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class BoxOrderViewModel
{
    [JsonPropertyName("caixa_id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("produtos")] 
    public IEnumerable<string> Products { get; set; } = [];
}