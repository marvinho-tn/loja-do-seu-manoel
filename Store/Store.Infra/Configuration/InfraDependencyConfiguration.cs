using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Infra.Repositories;

namespace Store.Infra.Configuration;

/// <summary>
/// Classe de configuração das dependências de infra.
/// </summary>
public static class InfraDependencyConfiguration
{
    /// <summary>
    /// Método de adição das dependencias da infra usando extensão.
    /// </summary>
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddTransient<IBoxRepository, BoxRepository>();

        return services;
    }
}