using Store.Domain.Entities;

namespace Store.Api.Models;

/// <summary>
/// Classe de extensao do resultado de processamento do pedido.
/// </summary>
public static class CreateOrderViewModelExtensions
{
    /// <summary>
    /// Método que pega o resultado e converte para a view.
    /// </summary>
    /// <param name="orders">Objeto de resultado.</param>
    /// <returns>Objeto de resultado com a view.</returns>
    public static IEnumerable<CreateOrderViewModel>? ConvertToViewModelResult(this IEnumerable<Order>? orders)
    {
        if (orders is null)
        {
            return null;
        }
        
        return orders.Select(order => new CreateOrderViewModel
        {
            Id = order.Id.Value,
            Boxes = order.Boxes.Select(box => new BoxOrderViewModel
            {
                Id = box.Id,
                Products = box.Products.Select(product => product.Id.Value),
            }),
        });
    }
}