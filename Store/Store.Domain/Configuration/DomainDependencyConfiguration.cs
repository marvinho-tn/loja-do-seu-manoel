using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Validations;

namespace Store.Domain.Configuration;

public static class DomainDependencyConfiguration
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddTransient<ProcessOrdersValidation>();
        services.AddTransient<PostProcessOrdersValidation>();

        return services;
    }
}