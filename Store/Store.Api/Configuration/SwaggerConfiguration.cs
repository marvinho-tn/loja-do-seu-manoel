using Microsoft.OpenApi.Models;

namespace Store.Api.Configuration;

/// <summary>
/// Classe de configuração da documentação da API.
/// </summary>
public static class SwaggerConfiguration
{
    /// <summary>
    /// Método de adição da configuração aos serviços da API.
    /// </summary>
    public static IServiceCollection AddStoreSwagger(this IServiceCollection services)
    {
        // Configurando o Swagger para suportar JWT
        return services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Store API", Version = "v1" });

            // Definindo o esquema de segurança
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Insira o token JWT desta forma: Bearer {seu token}"
            });

            // Requisitando o uso do token nas requisições protegidas
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}