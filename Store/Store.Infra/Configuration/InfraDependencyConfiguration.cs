using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Infra.Configuration.Database;
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
        return services
            .AddTransient<IBoxRepository, BoxRepository>()
            .AddTransient<IOrderRepository, OrderRepository>()
            .AddTransient<IProductRepository, ProductRepository>()
            .AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("StoreDb"));
    }

    /// <summary>
    /// Método de configuração da infra.
    /// </summary>
    public static IApplicationBuilder UseInfra(this IApplicationBuilder app)
    {
        var context = app.ApplicationServices.GetRequiredService<StoreDbContext>();
        var isCreated = context.Database.EnsureCreated();

        Console.WriteLine($"Banco de dados Store is created? {isCreated}");
        
        return app;
    }
}