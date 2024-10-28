namespace Store.Infra.Services;

public interface IAuthService
{
    string? Auth(string username, string password);
}