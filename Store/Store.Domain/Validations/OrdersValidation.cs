using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Validations;

public class ProccessOrdersValidation
{
    public Result<List<Order>> Validate(List<Order> orders)
    {
        var result = new Result<List<Order>>();
        
        if (!orders.Any())
        {
            result.AddValidation(ValidationType.OrderListCannotBeEmpty);
        }

        if (!orders.All(order => order.Products.Any()))
        {
            result.AddValidation(ValidationType.ProductOrderListCannotBeEmpty);
        }
        
        return result;
    }
}

public class PostProccessOrdersValidation
{
    public Result<List<Order>> Validate(List<Order> orders)
    {
        var result = new Result<List<Order>>();

        if (orders.Any(order => !order.Boxes.Any()))
        {
            result.AddValidation(ValidationType.ImpossibleToBoxOrder);
        }
        
        return result;
    }
}