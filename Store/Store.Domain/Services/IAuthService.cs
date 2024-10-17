namespace Store.Domain.Services;

public interface IAuthService
{
    string? Auth(string username, string password);
}