namespace Recipes.Service.Data.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public List<UserRole> UserRoles { get; set; } = new();
}