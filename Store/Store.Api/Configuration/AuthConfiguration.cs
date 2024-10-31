using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Store.Infra.Services;
using Store.Infra.Services.Implementations;
using Store.Infra.Utils;

namespace Store.Api.Configuration;

/// <summary>
/// Classe de configuração da autenticação na API.
/// </summary>
public static class AuthConfiguration
{
    /// <summary>
    /// Método de adição da configuração aos serviços da API.
    /// </summary>
    public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        // Mapeia a seção JwtSettings do appsettings.json
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        var jwtSettingsSection = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettingsSection["SecretKey"];
        var issuer = jwtSettingsSection["Issuer"];
        var audience = jwtSettingsSection["Audience"];

        // Adiciona o serviço de autenticação JWT
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                };
            });
        // Injeta serviços de autorização
        services.AddTransient<IAuthService, AuthService>();
    }
}