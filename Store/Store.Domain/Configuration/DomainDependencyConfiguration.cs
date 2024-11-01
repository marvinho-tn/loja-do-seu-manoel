using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Validations;

namespace Store.Domain.Configuration;

/// <summary>
/// Classe de configuração das dependências de domínio.
/// </summary>
public static class DomainDependencyConfiguration
{
    /// <summary>
    /// Método de adição das dependencias do dominio usando extensão.
    /// </summary>
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services
            .AddTransient<ProcessOrdersValidation>()
            .AddTransient<PostProcessOrdersValidation>();
    }
}