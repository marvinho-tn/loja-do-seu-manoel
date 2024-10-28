using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Api.Models;

public static class CreateOrderViewModelExtensions
{
    public static Result<List<CreateOrderViewModel>> ConvertToViewModelResult(this Result<List<Order>> ordersResult)
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