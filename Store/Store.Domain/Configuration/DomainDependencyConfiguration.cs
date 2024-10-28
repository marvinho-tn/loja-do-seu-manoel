using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Implementations;
using Store.Domain.Services;
using Store.Domain.Services.Application;

namespace Store.Domain.Configuration;

public static class DomainDependencyConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();
        services.AddTransient<IBoxRepository, BoxRepository>();

        return services;
    }
}