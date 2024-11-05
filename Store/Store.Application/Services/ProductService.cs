using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Services;
using Store.Domain.Utils;

namespace Store.Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public Result<IEnumerable<Product>> GetAllProducts()
    {
        var products = productRepository.GetAllProducts();
        var result = new Result<IEnumerable<Product>>(products);
        
        return result;
    }
}