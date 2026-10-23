namespace Recipes.Service.Data.Entities;

public class RecipeRating
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public int Rating { get; set; }
    public DateTime DateRating { get; set; }
}