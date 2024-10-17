using Microsoft.AspNetCore.Mvc;
using Store.Api.Models;
using Store.Domain.Services;

[ApiController]
[Route("autenticacao")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserLoginModel login)
    {
        var token = authService.Auth(login.Username, login.Password);
        
        return token != null ? Ok(new { token }) : Unauthorized();
    }
}