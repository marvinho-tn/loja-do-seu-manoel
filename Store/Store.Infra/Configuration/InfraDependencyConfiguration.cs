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
        services.AddTransient<IBoxRepository, BoxRepository>();

        services.AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("StoreDb"));

        return services;
    }

    public static IApplicationBuilder UseInfra(this IApplicationBuilder app)
    {
        var context = app.ApplicationServices.GetRequiredService<StoreDbContext>();
        
        context.Database.EnsureCreated();

        return app;
    }
}