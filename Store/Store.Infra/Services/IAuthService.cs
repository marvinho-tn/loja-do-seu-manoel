namespace Store.Infra.Services;

/// <summary>
/// Interface de representação da autenticação dos serviços.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Método de autenticação.
    /// </summary>
    /// <param name="username">Usuário a ser autenticado.</param>
    /// <param name="password">Senha do usuário.</param>
    /// <returns>Token de autenticação.</returns>
    string? Auth(string username, string password);
}