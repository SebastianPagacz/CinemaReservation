
using User.Domain.Infrastrucutre;
using User.Domain.Models;

namespace User.Domain.Seeder;

public class UserSeeder(AppDbContext context) : IUserSeeder
{
    public async Task SeedAsync()
    {
        if (!context.Roles.Any())
        {
            var roles = new List<RoleModel> 
            {
                new RoleModel { Name = "admin" },
                new RoleModel { Name = "employee" },
                new RoleModel { Name = "customer" }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();
        }
    }
}
