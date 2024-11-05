using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Infra.Configuration.Database;

namespace Store.Infra.Repositories;

public class ProductRepository(StoreDbContext context) : IProductRepository
{
    public IEnumerable<Product> GetAllProducts()
    {
        return context.Set<Product>().ToList();
    }
}