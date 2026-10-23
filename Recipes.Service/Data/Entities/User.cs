namespace Recipes.Service.Data.Entities;

public class User
{
    public int Id;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateOnly DateRegistration { get; set; }
    public DateTime BirthDay { get; set; }
    public string LinkPhoto { get; set; }
    
    
    public List<UserRole> UserRoles { get; set; } = new();
    public List<Recipe> Recipes { get; set; } = new();
    public List<RecipeRating> Ratings { get; set; } = new();
    public List<Favorite> Favorites { get; set; } = new();
}