namespace Store.Infra.Utils;

/// <summary>
/// Classe que representa as configurações de token de autenticação.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Segredo do token
    /// </summary>
    public string SecretKey { get; set; }
    
    /// <summary>
    /// Emissor do token
    /// </summary>
    public string Issuer { get; set; }
    
    /// <summary>
    /// Audiencia do token
    /// </summary>
    public string Audience { get; set; }
    
    /// <summary>
    /// Usuário padrão
    /// </summary>
    public string DefaultUsername { get; set; }
    
    /// <summary>
    /// Senha padrão.
    /// </summary>
    public string DefaultPassword { get; set; }
}