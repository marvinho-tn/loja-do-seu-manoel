using System.Text.Json.Serialization;

namespace Store.Api.Models;

/// <summary>
/// Modelo de login de usuário.
/// </summary>
public class UserLoginModel
{
    /// <summary>
    /// Nome do usuário
    /// </summary>
    [JsonPropertyName("usuario")] 
    public string Username { get; set; } = null!;
    
    /// <summary>
    /// Senha do usuário.
    /// </summary>
    [JsonPropertyName("senha")]
    public string Password { get; set; } = null!;
}