using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class ProductOrderModel
{
    [Required]
    [JsonPropertyName("produto_id")]
    public string Id { get; set; }

    [Required]
    [JsonPropertyName("dimensoes")]
    public MeasurableModel Dimensions { get; set; }
}