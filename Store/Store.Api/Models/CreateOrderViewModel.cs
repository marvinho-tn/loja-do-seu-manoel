using System.Text.Json.Serialization;
using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Api.Models;

public class CreateOrderViewModel
{
    [JsonPropertyName("pedido_id")]
    public uint Id { get; set; }

    [JsonPropertyName("caixas")] 
    public IEnumerable<BoxOrderViewModel> Boxes { get; set; } = [];
}