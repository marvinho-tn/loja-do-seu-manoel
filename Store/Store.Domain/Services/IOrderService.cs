using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Services;

public interface IOrderService
{
    Task<Result<List<Order>>> ProccessOrdersAsync(List<Order> orders);
}