using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

public class CreateOrdersModel
{
    [JsonPropertyName("pedidos")] 
    public IEnumerable<CreateOrderModel> Orders { get; set; } = [];

    public List<Order> ConvertToOrder()
    {
        return Orders.Select(order => order.ConvertToOrder()).ToList();
    }
}