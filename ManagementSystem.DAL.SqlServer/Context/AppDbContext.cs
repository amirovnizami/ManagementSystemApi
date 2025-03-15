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
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductIngredient>()
            .HasKey(pi => new { pi.ProductId, pi.IngredientId });
        modelBuilder.Entity<ProductDepartment>()
            .HasKey(pd => new { pd.ProductId, pd.DepartmentId });
        modelBuilder.Entity<ProductAllergenGroup>()
            .HasKey(pag => new { pag.ProductId, pag.AllergenGroupId });
    }
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