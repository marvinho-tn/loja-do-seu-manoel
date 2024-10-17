using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Store.Api.Models;

public class UserLoginModel
{
    [Required]
    [JsonPropertyName("usuario")]
    public string Username { get; set; }
    
    [Required]
    [JsonPropertyName("senha")]
    public string Password { get; set; }
}