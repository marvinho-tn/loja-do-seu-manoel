using Store.Domain.ApplicationServices;
using Store.Domain.Entities;

namespace Store.Tests.Services;

public class OrderServiceTests
{
    [Fact]
    public async void ShouldBeSuccessful_WhenOrderIsProcessed()
    {
        //Arrange
        var service = new OrderService();
        var orders = new List<Order>();
        
        //Act
        var result = await service.ProccessOrdersAsync(orders);

        //Asserts
        Assert.NotNull(result);
        Assert.Equivalent(orders.Count, result.Obj.Count);
    }
}