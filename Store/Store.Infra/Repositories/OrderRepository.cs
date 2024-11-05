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

    public IEnumerable<Order> GetAll()
    {
        return context.Set<Order>().ToList();
    }
}