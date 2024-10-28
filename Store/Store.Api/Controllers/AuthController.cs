using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Infra.Services;

[ApiController]
[Route("autenticacao")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginModel login)
    {
        var token = authService.Auth(login.Username, login.Password);
        
        return token is not null ? Ok(new { token }) : Unauthorized();
    }
}