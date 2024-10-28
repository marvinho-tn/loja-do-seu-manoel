using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Services;

public interface IOrderService
{
    Result<List<Order>> ProcessOrders(List<Order> orders);
}