namespace User.Application.Services;

public interface ILoginService
{
    Task<bool> RegisterAsync(string email, string username, string passowrd);
    Task<string> LoginAsync(string email, string passowrd);
}
