namespace Recipes.Service.Data.Entities;

public class Composition
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;
    public decimal Quantity { get; set; }
    public string MeasureUnit { get; set; } = null!;
}