using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class UserLoginModel
{
    [JsonPropertyName("usuario")]
    public string Username { get; set; }
    
    [JsonPropertyName("senha")]
    public string Password { get; set; }
}