using Microsoft.Extensions.DependencyInjection;
using Store.Application.Services;
using Store.Domain.Services;

namespace Store.Application.Configuration;

public static class ApplicationDependencyConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();

        return services;
    }
}