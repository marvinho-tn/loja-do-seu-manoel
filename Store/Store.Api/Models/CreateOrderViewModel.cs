using System.Text.Json.Serialization;
using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Api.Models;

public class CreateOrderViewModel
{
    [JsonPropertyName("pedido_id")]
    public uint Id { get; set; }
    
    [JsonPropertyName("caixas")]
    public List<BoxOrderViewModel> Boxes { get; set; }
}

public static class CreateOrderViewModelExtensions
{
    public static Result<List<CreateOrderViewModel>> ToViewModelResult(this Result<List<Order>> ordersResult)
    {
        return new Result<List<CreateOrderViewModel>>()
        {
            Obj = ordersResult.Obj.Select(order => new CreateOrderViewModel
            {
                Id = order.Id,
                Boxes = order.Boxes.Select(box => new BoxOrderViewModel
                {
                    Id = box.Id,
                    Products = box.Products.Select(product => product.Id).ToList(),
                }).ToList(),
            }).ToList(),
            Validations = ordersResult.Validations,
        };
    }
}