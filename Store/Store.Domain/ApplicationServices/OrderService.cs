using Store.Domain.Entities;
using Store.Domain.Services;
using Store.Domain.Utils;

namespace Store.Domain.ApplicationServices;

public class OrderService : IOrderService
{
    public async Task<Result<List<Order>>> ProccessOrdersAsync(List<Order> orders)
    {
        return new Result<List<Order>>();
    }
}