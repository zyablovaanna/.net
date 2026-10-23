namespace Recipes.Service.Data.Entities;

public class Recipe
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public User Author { get; set; }
    public string Name { get; set; } = null!;
    public int Complexity { get; set; }
    public int Spiciness { get; set; }
    public int CookingTime { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string? Occasion { get; set; }
    public string? TypeDish { get; set; }
    public string? Cuisine { get; set; }
    public string? Meal { get; set; }
    public string? LinkPhoto { get; set; }

    public List<Step> Steps { get; set; } = new();
    public List<Composition> Compositions { get; set; } = new();
    public List<RecipeRating> Ratings { get; set; } = new();
    public List<Favorite> Favorites { get; set; } = new();



}