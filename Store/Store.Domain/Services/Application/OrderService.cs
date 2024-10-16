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

        foreach (var order in orders)
        {
            await ProccessOrderAsync(boxRepository, order);
        }
        
        result.Obj = orders;
        
        return result;
    }

    private static async Task ProccessOrderAsync(IBoxRepository boxRepository, Order order)
    {
        var boxes = (await boxRepository.GetAllTypesOfBoxesAsync()).OrderBy(box => box.Volume);

        BoxProducts(boxes, order);
    }

    private static void BoxProducts(IEnumerable<Box> boxes, Order order)
    {
        var productsNotBoxed = order.Products.Where(product => !order.IsBoxed(product)).ToList();
        
        //tenta colocar todos os produtos em uma unica caixa
        foreach (var box in boxes)
        {
            if (box.AllProductsFit(productsNotBoxed))
            {
                order.Box(productsNotBoxed, box);
            }

            return;
        }
        
        //pega a menor caixa para colocar o maximo de produtos
        var biggestBox = order.Boxes.MaxBy(box => box.Volume);

        foreach (var product in productsNotBoxed)
        {
            if (biggestBox.RemainderVolume > product.Volume)
            {
                order.Box(product, biggestBox);
            }
        }
        
        //refazer o processo
        BoxProducts(boxes, order);
    }
}