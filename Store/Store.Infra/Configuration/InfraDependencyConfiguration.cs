using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Infra.Repositories;

namespace Store.Infra.Configuration;

public static class InfraDependencyConfiguration
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddTransient<IBoxRepository, BoxRepository>();

        return services;
    }
}