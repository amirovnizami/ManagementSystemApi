using ManagementSystem.Domain.Entites;
using ManagmentSystem.Domain.Entites;
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
}