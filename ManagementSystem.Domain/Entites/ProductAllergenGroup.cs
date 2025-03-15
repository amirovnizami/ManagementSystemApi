using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Domain.Entites;

public class ProductAllergenGroup
{
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    [ForeignKey(nameof(AllergenGroup))]
    public int AllergenGroupId { get; set; }
    
    public Product Product { get; set; }
    public AllergenGroup AllergenGroup { get; set; }
}