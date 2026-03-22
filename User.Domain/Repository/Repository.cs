using Microsoft.EntityFrameworkCore;
using User.Domain.Infrastrucutre;
using User.Domain.Models;

namespace User.Domain.Repository;

public class Repository(AppDbContext context) : IRepository
{
    public async Task<bool> AddUserAsync(UserModel user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        
        return true;
    }

    public async Task<UserModel> GetUserByIdAsync(int id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<List<UserModel>> GetUsersAsync()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<bool> ValidateUserEmailAsync(string email)
    {
        return await context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<UserModel> GetUserByEmailAsync(string email)
    {
        return await context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
    }

    // Role

    public async Task<List<RoleModel>> GetRolesAsync()
    {
        return await context.Roles.ToListAsync();
    }

    public async Task<RoleModel> GetRoleByIdAsync(int id)
    {
        return await context.Roles.FirstOrDefaultAsync(r => r.Id == id);
    }
}
