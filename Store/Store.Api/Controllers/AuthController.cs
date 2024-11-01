using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Infra.Services;

/// <summary>
/// Controller de autenticação da API.
/// </summary>
/// <param name="authService">Serviço que controla o processo de autenticação.</param>
[ApiController]
[Route("autenticacao")]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Endpoint de login
    /// </summary>
    /// <param name="login">Dados do login.</param>
    /// <returns>Resultado do login.</returns>
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginModel login)
    {
        var token = authService.Auth(login.Username, login.Password);
        var result = new ResultViewModel(new { token });
        
        return token is not null ? Ok(result) : Unauthorized(result);
    }
}