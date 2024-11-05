using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Services;

/// <summary>
/// Interface de representação do serviço de pedidos.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Método de processamento de pedidos.
    /// </summary>
    /// <param name="orders">Pedidos a serem processados.</param>
    /// <returns>Listagem de pedidos processados.</returns>
    Result<List<Order>> ProcessOrders(List<Order> orders);
    
    /// <summary>
    /// Método de listagem de pedidos.
    /// </summary>
    /// <returns>Listagem de pedidos.</returns>
    Result<IEnumerable<Order>> GetAllOrders();
}