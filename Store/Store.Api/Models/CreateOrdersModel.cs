using System.Text.Json.Serialization;
using Store.Domain.Entities;

namespace Store.Api.Models;

/// <summary>
/// Modelo de criação dos pedidos.
/// </summary>
public class CreateOrdersModel
{
    /// <summary>
    /// Listagem de pedidos.
    /// </summary>
    [JsonPropertyName("pedidos")] 
    public IEnumerable<CreateOrderModel> Orders { get; set; } = [];

    /// <summary>
    /// Método de conversão para o domínio.
    /// </summary>
    /// <returns>Listagem de entidades de pedido.</returns>
    public List<Order> ConvertToOrder()
    {
        return Orders.Select(order => order.ConvertToOrder()).ToList();
    }
}