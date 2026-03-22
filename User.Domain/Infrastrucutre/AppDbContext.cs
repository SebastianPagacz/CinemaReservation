using Microsoft.EntityFrameworkCore;
using User.Domain.Models;

namespace User.Domain.Infrastrucutre;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<RoleModel> Roles { get; set; }
}
