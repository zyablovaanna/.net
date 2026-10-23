namespace Recipes.Service.Data.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;

    public List<Composition> Compositions { get; set; } = new();
}