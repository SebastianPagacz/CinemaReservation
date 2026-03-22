
using BCrypt.Net;
using User.Domain.Models;
using User.Domain.Repository;

namespace User.Application.Services;

public class LoginService(IRepository repository, IJWTService jwtService) : ILoginService
{
    public async Task<string> LoginAsync(string email, string passowrd)
    {
        var existingUser = await repository.GetUserByEmailAsync(email);

        if (existingUser is null)
            return "Nan"; // TODO: refactor add exceptions

        var passwordValidation = BCrypt.Net.BCrypt.Verify(passowrd, existingUser.PasswordHash);
        if (passwordValidation)
            return jwtService.GenerateToken(existingUser);

        return "Nan";
    }

    public async Task<bool> RegisterAsync(string email, string username, string passowrd)
    {
        if (await repository.ValidateUserEmailAsync(email))
            return false;

        var basicRole = await repository.GetRoleByIdAsync(2);
        Console.WriteLine(basicRole.Name);
        
        var user = new UserModel
        {
            Email = email,
            Username = username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(passowrd),
            RoleId = basicRole.Id
        };

        await repository.AddUserAsync(user);

        return true;
    }
}
