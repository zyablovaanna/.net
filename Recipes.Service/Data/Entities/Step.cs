namespace Recipes.Service.Data.Entities;

public class Step
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public int? StepNextId { get; set; }   
    public Step? StepNext { get; set; }
    public string TextStep { get; set; } = null!;
    public string? LinkPhoto { get; set; }
}