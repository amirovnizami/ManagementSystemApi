using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Domain.Entites;

public class ProductIngredient
{
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    [ForeignKey(nameof(Ingredient))]
    public int IngredientId { get; set; }

    public Product Product { get; set; }
    public Ingredient Ingredient { get; set; }
}