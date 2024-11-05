using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

/// <summary>
/// Modelo de criação de pedido.
/// </summary>
public class CreateOrderModel
{
    /// <summary>
    /// Listagem de produtos contidos no pedido.
    /// </summary>
    [JsonPropertyName("produtos")]
    public IEnumerable<ProductOrderModel> Products { get; set; } = [];

    /// <summary>
    /// Método de conversão do pedido para o domínio.
    /// </summary>
    /// <returns>Entidade de domínio com o pedido.</returns>
    public Order ConvertToOrder()
    {
        return new Order(true)
        {
            Products = Products.Select(product => product.ConvertToProduct()).ToList()
        };
    }
}