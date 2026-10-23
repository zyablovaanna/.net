namespace Recipes.Service.Data.Entities;

public class Appeal
{
    public int Id { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; } = null!;
    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;
    public int? EmployeeId { get; set; }   
    public User? Employee { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ClosingDate { get; set; }
    public string StatusAppeal { get; set; } = null!;
    public string TypeAppeal { get; set; } = null!;
    public string Message { get; set; } = null!;
}