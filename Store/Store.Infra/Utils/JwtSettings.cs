namespace Store.Infra.Utils;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string DefaultUsername { get; set; }
    public string DefaultPassword { get; set; }
}