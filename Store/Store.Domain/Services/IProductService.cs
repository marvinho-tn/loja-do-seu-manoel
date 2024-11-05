using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Services;

public interface IProductService
{
    Result<IEnumerable<Product>> GetAllProducts();
}