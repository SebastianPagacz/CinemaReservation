using System.ComponentModel.DataAnnotations;

namespace User.Domain.Models;

public class UserModel
{
    public int Id { get; set; }
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    
    public int RoleId { get; set; }
    public RoleModel Role { get; set; }
}
