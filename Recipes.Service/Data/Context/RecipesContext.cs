using Microsoft.EntityFrameworkCore;
using Recipes.Service.Data.Entities;

namespace Recipes.Service.Data.Context;

public class RecipesContext : DbContext
{
    public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Step> Steps => Set<Step>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Composition> Compositions => Set<Composition>();
    public DbSet<RecipeRating> Ratings => Set<RecipeRating>();
    public DbSet<Favorite> Favorites => Set<Favorite>();
    public DbSet<ModerationDecision> ModerationDecisions => Set<ModerationDecision>();
    public DbSet<Appeal> Appeals => Set<Appeal>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Users");
            e.Property(x => x.Name).HasMaxLength(100);
            e.Property(x => x.Surname).HasMaxLength(100);
            e.Property(x => x.Login).HasMaxLength(50);
            e.Property(x => x.Email).HasMaxLength(255);
            e.HasIndex(x => x.Login).IsUnique();
            e.HasIndex(x => x.Email).IsUnique();
        });

        mb.Entity<Role>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Roles");
            e.Property(x => x.Name).HasMaxLength(50);
            e.HasIndex(x => x.Name).IsUnique();
        });

        mb.Entity<UserRole>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("RolesUser");
            e.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
            e.HasOne(x => x.User).WithMany(u => u.UserRoles).HasForeignKey(x => x.UserId);
            e.HasOne(x => x.Role).WithMany(r => r.UserRoles).HasForeignKey(x => x.RoleId);
        });

        mb.Entity<Recipe>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Recipes");
            e.Property(x => x.Name).HasMaxLength(200);
            e.HasOne(x => x.Author).WithMany(u => u.Recipes)
                .HasForeignKey(x => x.AuthorId).OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<Step>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Steps");
            e.HasOne(x => x.Recipe).WithMany(r => r.Steps)
                .HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.StepNext).WithMany()
                .HasForeignKey(x => x.StepNextId).OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<Ingredient>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Ingredients");
            e.Property(x => x.Name).HasMaxLength(150);
            e.HasIndex(x => x.Name).IsUnique();
        });

        mb.Entity<Composition>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Composition");
            e.Property(x => x.Quantity).HasPrecision(10, 2);
            e.Property(x => x.MeasureUnit).HasMaxLength(30);
            e.HasIndex(x => new { x.RecipeId, x.IngredientId }).IsUnique();
            e.HasOne(x => x.Recipe).WithMany(i => i.Compositions).HasForeignKey(x => x.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Ingredient).WithMany(i => i.Compositions)
                .HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<RecipeRating>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Rating");
            e.HasKey(x => x.Id);
            e.HasIndex(x => new { x.UserId, x.RecipeId }).IsUnique();
            e.HasOne(x => x.User).WithMany(u => u.Ratings)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Recipe).WithMany(r => r.Ratings)
                .HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<Favorite>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Favorites");
            e.HasIndex(x => new { x.UserId, x.RecipeId }).IsUnique();
            e.HasOne(x => x.User).WithMany(u => u.Favorites)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Recipe).WithMany(r => r.Favorites)
                .HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<ModerationDecision>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("ModerationDecisions");
            e.Property(x => x.StatusDecision).HasMaxLength(50);
            e.HasOne(x => x.Recipe).WithMany()
                .HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Moderator).WithMany()
                .HasForeignKey(x => x.ModeratorId).OnDelete(DeleteBehavior.Restrict);
        });

        mb.Entity<Appeal>(e =>
        {
            e.HasKey(x => x.Id);  
            e.ToTable("Appeals");
            e.Property(x => x.StatusAppeal).HasMaxLength(50);
            e.Property(x => x.TypeAppeal).HasMaxLength(50);
            e.HasOne(x => x.Recipe).WithMany()
                .HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Sender).WithMany()
                .HasForeignKey(x => x.SenderId).OnDelete(DeleteBehavior.Restrict);
            e.HasOne(x => x.Employee).WithMany()
                .HasForeignKey(x => x.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        });
    }
}