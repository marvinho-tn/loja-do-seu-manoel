using System.Text.Json.Serialization;
using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Api.Models;

public class CreateOrderViewModel
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
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
                Id = order.Id.Value,
                Boxes = order.Boxes.Select(box => new BoxOrderViewModel
                {
                    Id = box.Id.Value,
                    Height = box.Height,
                    Width = box.Width,
                    Length = box.Length,
                    Products = box.Products.Select(product => new ProductOrderViewModel
                    {
                        Height = product.Height,
                        Width = product.Width,
                        Length = product.Length,
                    }).ToList(),
                }).ToList(),
            }).ToList(),
            Validations = ordersResult.Validations,
        };
    }
}