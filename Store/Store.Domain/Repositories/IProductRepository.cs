using Store.Domain.Entities;

namespace Store.Domain.Repositories;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();
}