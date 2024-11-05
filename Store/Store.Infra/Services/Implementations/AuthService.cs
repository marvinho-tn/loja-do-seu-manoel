using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Store.Infra.Utils;

namespace Store.Infra.Services.Implementations;

/// <summary>
/// Classe de representação da autenticação dos serviços.
/// </summary>
public class AuthService(IOptions<JwtSettings> jwtSettings) : IAuthService
{
    /// <summary>
    /// Método de autenticação.
    /// </summary>
    /// <param name="username">Usuário a ser autenticado.</param>
    /// <param name="password">Senha do usuário.</param>
    /// <returns>Token de autenticação.</returns>
    public string? Auth(string username, string password)
    {
        if (username != jwtSettings.Value.DefaultUsername || password != jwtSettings.Value.DefaultPassword)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(jwtSettings.Value.SecretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", "1") }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtSettings.Value.Issuer,
            Audience = jwtSettings.Value.Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}