using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Utils;

namespace Store.Domain.Services.Application;

public class OrderService(IBoxRepository boxRepository): IOrderService
{
    public async Task<Result<List<Order>>> ProccessOrdersAsync(List<Order> orders)
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

        if (!result.IsValid())
        {
            return result;
        }

        var boxes = (await boxRepository.GetAllTypesOfBoxesAsync()).OrderBy(box => box.Volume).ToList();
        
        foreach (var order in orders)
        {
            BoxOrder(boxes, order);
        }

        if (orders.Any(order => !order.Boxes.Any()))
        {
            result.AddValidation(ValidationType.ImpossibleToBoxOrder);
            
            return result;
        }
        
        result.Obj = orders;
        
        return result;
    }

    private static void BoxOrder(List<BoxMold> boxes, Order order)
    {
        var productsNotBoxed = order.Products.Where(product => !order.IsBoxed(product)).ToList();
        
        //tenta colocar todos os produtos em uma unica caixa
        foreach (var boxMold in boxes)
        {
            var box = new Box(boxMold);
            
            if (box.AllProductsFit(productsNotBoxed))
            {
                order.Box(productsNotBoxed, box);
            }

            return;
        }
        
        //pega a menor caixa para colocar o maximo de produtos
        var biggestBoxMold = boxes.MaxBy(box => box.Volume);

        foreach (var product in productsNotBoxed)
        {
            var biggestBox = new Box(biggestBoxMold);

            if (biggestBox.RemainderVolume >= product.Volume)
            {
                order.Box(product, biggestBox);
            }
        }
        
        //refazer o processo
        BoxOrder(boxes, order);
    }
}