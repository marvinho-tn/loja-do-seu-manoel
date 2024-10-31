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
    public static IEnumerable<CreateOrderViewModel> ConvertToViewModelResult(this List<Order> ordersResult)
    {
        return ordersResult.Select(order => new CreateOrderViewModel
        {
            Id = order.Id,
            Boxes = order.Boxes.Select(box => new BoxOrderViewModel
            {
                Id = box.Id,
                Products = box.Products.Select(product => product.Id),
            }),
        });
    }
}