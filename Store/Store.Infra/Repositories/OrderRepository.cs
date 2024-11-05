using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Configuration.Database;

namespace Store.Infra.Repositories;

public class OrderRepository(StoreDbContext context) : IOrderRepository
{
    public void Save(IEnumerable<Order> orders)
    {
        context.AddRange(orders);
        context.SaveChanges();
    }

    public IEnumerable<Order> GetAllWithBoxesThenProducts()
    {
        return context
            .Set<Order>()
            .Include(order => order.Boxes)
            .ThenInclude(box => box.Products)
            .ToList();
    }
}