using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Api.Models;

/// <summary>
/// Classe de extensao do resultado de processamento do pedido.
/// </summary>
public static class CreateOrderViewModelExtensions
{
    /// <summary>
    /// Método que pega o resultado e converte para a view.
    /// </summary>
    /// <param name="ordersResult">Objeto de resultado.</param>
    /// <returns>Objeto de resultado com a view.</returns>
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