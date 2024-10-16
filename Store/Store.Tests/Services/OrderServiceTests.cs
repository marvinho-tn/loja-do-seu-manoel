using NSubstitute;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Services.Application;

namespace Store.Tests.Services;

public class OrderServiceTests
{
    [Fact]
    public async void ShouldBeSuccessful_WhenOrderIsProcessed()
    {
        //Arrange
        var boxRepository = Substitute.For<IBoxRepository>();
        var orderService = new OrderService(boxRepository);
        var orders = new List<Order>
        {
            new Order
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Height = 10,
                        Length = 10,
                        Width = 10,
                    },
                    new Product
                    {
                        Height = 20,
                        Length = 10,
                        Width = 10,
                    },
                    new Product
                    {
                        Height = 30,
                        Length = 10,
                        Width = 10,
                    },
                },
            },
            new Order
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Height = 10,
                        Length = 20,
                        Width = 10,
                    },
                    new Product
                    {
                        Height = 20,
                        Length = 20,
                        Width = 10,
                    },
                    new Product
                    {
                        Height = 30,
                        Length = 20,
                        Width = 10,
                    },
                },
            },
        };
        
        boxRepository.GetAllTypesOfBoxesAsync().Returns(new List<Box>
        {
            new Box
            {
                Height = 50,
                Width = 50,
                Length = 50,
            },
            new Box
            {
                Height = 30,
                Width = 50,
                Length = 50,
            },
            new Box
            {
                Height = 40,
                Width = 50,
                Length = 50,
            },
        });
        
        //Act
        var result = await orderService.ProccessOrdersAsync(orders);

        //Asserts
        Assert.NotNull(result);
        Assert.NotNull(result.Obj);
        Assert.Empty(result.Validations);
        Assert.Equivalent(orders.Count, result.Obj.Count);
        Assert.Equivalent(orders.Sum(order => order.Products.Count), result.Obj.Sum(order => order.Products.Count));
        Assert.Equivalent(result.Obj.Sum(order => order.Products.Count), result.Obj.Sum(order => order.Boxes.Sum(box => box.Products.Count)));
    }
}