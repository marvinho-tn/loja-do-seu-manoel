using NSubstitute;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Domain.Services.Application;
using Store.Domain.Utils;
using Store.Domain.Validations;

namespace Store.Tests.Services;

public class OrderServiceTests
{
    [Fact]
    public async void ItMustBePossibleToBoxSuccessfully_WhenProductsFitInASingleBox()
    {
        //Arrange
        var boxRepository = Substitute.For<IBoxRepository>();
        var proccessOrdersValidation = new ProccessOrdersValidation();
        var postProccessOrdersValidation = new PostProccessOrdersValidation();
        var orderService = new OrderService(boxRepository, proccessOrdersValidation, postProccessOrdersValidation);
        var orders = new List<Order>
        {
            new Order
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Dimensions = new Measurable
                        {
                            Height = 10,
                            Length = 10,
                            Width = 10,
                        }
                    },
                    new Product
                    {
                        Dimensions = new Measurable
                        {
                            Height = 20,
                            Length = 10,
                            Width = 10,
                        }
                    },
                    new Product
                    {
                        Dimensions = new Measurable
                        {
                            Height = 30,
                            Length = 10,
                            Width = 10,
                        }
                    },
                },
            },
            new Order
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        
                        Dimensions = new Measurable
                        {
                            Height = 10,
                            Length = 20,
                            Width = 10,
                        }
                    },
                    new Product
                    {
                        
                        Dimensions = new Measurable
                        {
                            Height = 20,
                            Length = 20,
                            Width = 10,
                        }
                    },
                    new Product
                    {
                        
                        Dimensions = new Measurable
                        {
                            Height = 30,
                            Length = 20,
                            Width = 10,
                        }
                    },
                },
            },
        };
        
        boxRepository.GetAllTypesOfBoxesAsync().Returns(new List<BoxMold>
        {
            new BoxMold
            {
                Height = 50,
                Width = 50,
                Length = 50,
            },
            new BoxMold
            {
                Height = 30,
                Width = 50,
                Length = 50,
            },
            new BoxMold
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
        Assert.True(result.Obj.All(order => order.Boxes.Count == 1));
    }
    
    [Fact]
    public async void ItMustBePossibleToPackInTheSmallestBoxPossible_WhenProductsFitInASingleBox()
    {
        //Arrange
        var boxRepository = Substitute.For<IBoxRepository>();
        var proccessOrdersValidation = new ProccessOrdersValidation();
        var postProccessOrdersValidation = new PostProccessOrdersValidation();
        var orderService = new OrderService(boxRepository, proccessOrdersValidation, postProccessOrdersValidation);
        var orders = new List<Order>
        {
            new Order
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        
                        Dimensions = new Measurable
                        {
                            Height = 10,
                            Length = 10,
                            Width = 10,
                        }
                    },
                    new Product
                    {
                        
                        Dimensions = new Measurable
                        {
                            Height = 20,
                            Length = 10,
                            Width = 10,
                        }
                    },
                    new Product
                    {
                        
                        Dimensions = new Measurable
                        {
                            Height = 30,
                            Length = 10,
                            Width = 10,
                        }
                    },
                },
            },
        };

        var boxMolds = new List<BoxMold>
        {
            new BoxMold
            {
                Height = 50,
                Width = 50,
                Length = 50,
            },
            new BoxMold
            {
                Height = 30,
                Width = 50,
                Length = 50,
            },
            new BoxMold
            {
                Height = 40,
                Width = 50,
                Length = 50,
            },
        };
        
        boxRepository.GetAllTypesOfBoxesAsync().Returns(boxMolds);
        
        //Act
        var result = await orderService.ProccessOrdersAsync(orders);

        //Asserts
        Assert.Empty(result.Validations);
        Assert.True(result.Obj[0].Boxes[0].OfType(boxMolds[1]));
    }

    [Fact]
    public async void ItShouldNotBePossibleToBox_WhenThereAreNoOrders()
    {
        //Arrange
        var boxRepository = Substitute.For<IBoxRepository>();
        var proccessOrdersValidation = new ProccessOrdersValidation();
        var postProccessOrdersValidation = new PostProccessOrdersValidation();
        var orderService = new OrderService(boxRepository, proccessOrdersValidation, postProccessOrdersValidation);
        var orders = new List<Order>();
        
        //Act
        var result = await orderService.ProccessOrdersAsync(orders);

        //Asserts
        Assert.NotNull(result);
        Assert.Null(result.Obj);
        Assert.NotEmpty(result.Validations);
        Assert.Contains(result.Validations, validation => validation.Type == ValidationType.OrderListCannotBeEmpty);
    }

    [Fact]
    public async void ItShouldNotBePossibleToBox_WhenThereAreNoProductsInTheOrders()
    {
        //Arrange
        var boxRepository = Substitute.For<IBoxRepository>();
        var proccessOrdersValidation = new ProccessOrdersValidation();
        var postProccessOrdersValidation = new PostProccessOrdersValidation();
        var orderService = new OrderService(boxRepository, proccessOrdersValidation, postProccessOrdersValidation);
        var orders = new List<Order>
        {
            new Order(),
            new Order(),
        };
        
        //Act
        var result = await orderService.ProccessOrdersAsync(orders);

        //Asserts
        Assert.NotNull(result);
        Assert.Null(result.Obj);
        Assert.NotEmpty(result.Validations);
        Assert.Contains(result.Validations, validation => validation.Type == ValidationType.ProductOrderListCannotBeEmpty);
    }

    [Fact]
    public async void ItShouldNotBePossibleToBox_WhenTheProductDoesNotFitInAvailableBoxes()
    {
        //Arrange
        var boxRepository = Substitute.For<IBoxRepository>();
        var proccessOrdersValidation = new ProccessOrdersValidation();
        var postProccessOrdersValidation = new PostProccessOrdersValidation();
        var orderService = new OrderService(boxRepository, proccessOrdersValidation, postProccessOrdersValidation);
        var orders = new List<Order>
        {
            new Order
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Dimensions = new Measurable
                        {
                            Height = 150,
                            Length = 150,
                            Width = 200,
                        }
                    },
                },
            },
        };
        
        boxRepository.GetAllTypesOfBoxesAsync().Returns(new List<BoxMold>
        {
            new BoxMold
            {
                Height = 50,
                Width = 50,
                Length = 50,
            },
            new BoxMold
            {
                Height = 30,
                Width = 50,
                Length = 50,
            },
            new BoxMold
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
        Assert.Null(result.Obj);
        Assert.NotEmpty(result.Validations);
        Assert.Contains(result.Validations, validation => validation.Type == ValidationType.ImpossibleToBoxOrder);
    }
}