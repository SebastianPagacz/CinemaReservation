using User.Domain.Models;

namespace User.Domain.Repository;

public interface IRepository
{
    Task<bool> AddUserAsync(UserModel user);
    Task<UserModel> GetUserByIdAsync(int id);
    Task<List<UserModel>> GetUsersAsync();
    Task<bool> ValidateUserEmailAsync(string email);
    Task<UserModel> GetUserByEmailAsync(string email);
    // Role
    Task<List<RoleModel>> GetRolesAsync();
    Task<RoleModel> GetRoleByIdAsync(int id);
}
