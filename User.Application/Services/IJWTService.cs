using User.Domain.Models;

namespace User.Application.Services;

public interface IJWTService
{
    public string GenerateToken(UserModel user);
}
