using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Implementations;
using Store.Domain.Validations;

namespace Store.Domain.Configuration;

public static class DomainDependencyConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        //Repositórios
        services.AddTransient<IBoxRepository, BoxRepository>();
        
        //Validações
        services.AddTransient<ProcessOrdersValidation>();
        services.AddTransient<PostProcessOrdersValidation>();

        return services;
    }
}