using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

public class CreateOrderModel
{
    [Required]
    [JsonPropertyName("pedido_id")]
    public uint Id { get; set; }
    
    [Required]
    [JsonPropertyName("produtos")]
    public List<ProductOrderModel> Products { get; set; } = [];

    public Order ConvertToOrder()
    {
        var order = new Order
        {
            Id = Id,
            Products = Products.Select(product => new Product
            {
                Id = product.Id,
                Dimensions = new Measurable
                {
                    Height = product.Dimensions.Height,
                    Width = product.Dimensions.Width,
                    Length = product.Dimensions.Length,
                },
            }).ToList()
        };

        return order;
    }
}