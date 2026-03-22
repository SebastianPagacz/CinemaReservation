namespace User.Domain.Models;

public class RoleModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<UserModel> Users { get; set; } = new List<UserModel>();
}
