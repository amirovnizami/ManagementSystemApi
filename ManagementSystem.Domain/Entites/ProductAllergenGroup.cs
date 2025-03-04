namespace ManagementSystem.Domain.Entites;

public class ProductAllergenGroup
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int AllergenGroupId { get; set; }
    public AllergenGroup AllergenGroup { get; set; }
}