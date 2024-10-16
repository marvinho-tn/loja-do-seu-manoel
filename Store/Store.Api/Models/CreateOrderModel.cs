using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

public class CreateOrderModel
{
    [Required]
    [JsonPropertyName("produtos")]
    public List<ProductOrderModel> Products { get; set; } = [];

    public Order ConvertToOrder()
    {
        var order = new Order(true)
        {
            Products = Products.Select(product => new Product
            {
                Width = product.Width,
                Height = product.Height,
                Length = product.Length
            }).ToList()
        };

        return order;
    }
}

public static class CreateOrderModelExtensions
{
    public static List<Order> ConvertToOrder(this List<CreateOrderModel> orders)
    {
        return orders.Select(order => order.ConvertToOrder()).ToList();
    }
}