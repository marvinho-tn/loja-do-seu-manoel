using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Store.Domain.Services;
using Store.Domain.Services.Infra;
using Store.Domain.Utils;

namespace Store.Api.Configuration;

public static class AuthConfiguration
{
    public static void ConfigureAuth(this WebApplicationBuilder builder)
    {
        // Mapeia a seção JwtSettings do appsettings.json
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

        var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
        var secretKey = jwtSettingsSection["SecretKey"];
        var issuer = jwtSettingsSection["Issuer"];
        var audience = jwtSettingsSection["Audience"];

        // Adiciona o serviço de autenticação JWT
        builder.Services.AddAuthentication(options =>
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
        builder.Services.AddTransient<IAuthService, AuthService>();
    }
}