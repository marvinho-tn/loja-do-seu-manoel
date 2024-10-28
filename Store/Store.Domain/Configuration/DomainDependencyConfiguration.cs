using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Implementations;
using Store.Domain.Services;
using Store.Domain.Services.Application;
using Store.Domain.Validations;

namespace Store.Domain.Configuration;

public static class DomainDependencyConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        //Serviços
        services.AddTransient<IOrderService, OrderService>();
        
        //Repositórios
        services.AddTransient<IBoxRepository, BoxRepository>();
        
        //Validações
        services.AddTransient<ProccessOrdersValidation>();
        services.AddTransient<PostProccessOrdersValidation>();

        return services;
    }
}