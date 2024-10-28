using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

public class CreateOrderModel
{
    [JsonPropertyName("pedido_id")] 
    public uint Id { get; set; }
    
    [JsonPropertyName("produtos")]
    public IEnumerable<ProductOrderModel> Products { get; set; } = [];

    public Order ConvertToOrder()
    {
        return new Order
        {
            Id = Id,
            Products = Products.Select(product => product.ConvertToProduct()).ToList()
        };
    }
}