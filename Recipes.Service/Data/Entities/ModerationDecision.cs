namespace Recipes.Service.Data.Entities;

public class ModerationDecision
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public int ModeratorId { get; set; }
    public User Moderator { get; set; } = null!;
    public string? Comment { get; set; }
    public DateTime DecisionDate { get; set; }
    public string StatusDecision { get; set; } = null!;
}