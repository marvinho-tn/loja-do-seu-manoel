using Store.Domain.Entities;
using Store.Domain.Utils;

namespace Store.Domain.Validations;

/// <summary>
/// Classe de representação de validações para o processamento de pedidos.
/// </summary>
public class ProcessOrdersValidation
{
    /// <summary>
    /// Metodo de execução das validações a partir de uma lista de pedidos.
    /// </summary>
    /// <param name="orders">Pedidos a ser validados.</param>
    /// <returns>Resultado das validações.</returns>
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

/// <summary>
/// Classe de representação de validações após o processamento de pedidos.
/// </summary>
public class PostProcessOrdersValidation
{
    /// <summary>
    /// Metodo de execução das validações a partir de uma lista de pedidos.
    /// </summary>
    /// <param name="orders">Pedidos a ser validados.</param>
    /// <returns>Resultado das validações.</returns>
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