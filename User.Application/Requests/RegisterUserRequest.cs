using System.ComponentModel.DataAnnotations;

namespace User.Application.Requests;

public class RegisterUserRequest
{
    public string Username { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}
