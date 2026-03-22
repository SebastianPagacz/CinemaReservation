using System.ComponentModel.DataAnnotations;

namespace User.Application.DTO;

public class UserDTO
{
    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public int RoleName { get; set; }
}
