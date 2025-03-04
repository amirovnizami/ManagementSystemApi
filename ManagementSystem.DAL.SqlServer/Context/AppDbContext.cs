using ManagementSystem.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.DAL.SqlServer.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<AllergenGroup> AllergenGroups { get; set; }
    public DbSet<ProductIngredient> ProductIngredients { get; set; }
    public DbSet<ProductDepartment> ProductDepartments { get; set; }

    public DbSet<ProductAllergenGroup> ProductAllergenGroups { get; set; }
    //
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<ProductIngredient>()
    //         .HasKey(pi => new { pi.ProductId, pi.IngredientId });
    //     modelBuilder.Entity<ProductIngredient>()
    //         .HasOne(pi => pi.Product)
    //         .WithMany(p => p.ProductIngredients)
    //         .HasForeignKey(pi => pi.ProductId);
    // }
    
}