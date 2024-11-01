using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Services;
using Store.Domain.Utils;
using Store.Domain.Validations;

namespace Store.Application.Services;

/// <summary>
/// Classse de representação do serviço de pedidos.
/// </summary>
public class OrderService
(
    IBoxRepository boxRepository, 
    ProcessOrdersValidation processOrdersValidation, 
    PostProcessOrdersValidation postProcessOrdersValidation
): 
    IOrderService
{
    /// <summary>
    /// Método de processamento de pedidos.
    /// </summary>
    /// <param name="orders">Pedidos a serem processados.</param>
    /// <returns>Listagem de pedidos processados.</returns>
    public Result<List<Order>> ProcessOrders(List<Order> orders)
    {
        var result = processOrdersValidation.Validate(orders);
        
        if (!result.IsValid())
        {
            return result;
        }

        var boxesMolds = boxRepository.GetAllTypesOfBoxes().OrderBy(boxMold => boxMold.Volume);

        if (!boxesMolds.Any())
        {
            result.AddValidation(ValidationType.EmptyBoxMoldList);

            return result;
        }
        
        foreach (var order in orders)
        {
            BoxOrder(boxesMolds, order);
        }
        
        result = postProcessOrdersValidation.Validate(orders);
        
        if (!result.IsValid())
        {
            return result;
        }
        
        result.Obj = orders;
        
        return result;
    }

    private static void BoxOrder(IEnumerable<BoxMold> boxesMolds, Order order)
    {
        var productsNotBoxed = order.Products.Where(product => !order.IsBoxed(product)).ToList();
        
        //tenta colocar todos os produtos em uma unica caixa
        foreach (var boxMold in boxesMolds)
        {
            var box = new Box(boxMold);
            
            if (box.AllProductsFit(productsNotBoxed))
            {
                order.Box(productsNotBoxed, box);
            }

            return;
        }
        
        //pega a menor caixa para colocar o maximo de produtos
        var biggestBoxMold = boxesMolds.MaxBy(box => box.Volume);

        foreach (var product in productsNotBoxed)
        {
            var biggestBox = new Box(biggestBoxMold);

            if (biggestBox.RemainderVolume >= product.Dimensions.Volume)
            {
                order.Box(product, biggestBox);
            }
        }
        
        //refazer o processo
        BoxOrder(boxesMolds, order);
    }
}