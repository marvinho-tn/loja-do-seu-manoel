using Microsoft.Extensions.DependencyInjection;
using Store.Application.Services;
using Store.Domain.Services;

namespace Store.Application.Configuration;

/// <summary>
/// Classe de configuração das dependências de aplicação.
/// </summary>
public static class ApplicationDependencyConfiguration
{
    /// <summary>
    /// Método de adição das dependencias da aplicação usando extensão.
    /// </summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddTransient<IOrderService, OrderService>();
    }
}