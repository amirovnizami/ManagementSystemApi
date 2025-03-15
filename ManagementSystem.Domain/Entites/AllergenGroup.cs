using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entites;

public class AllergenGroup:BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public ICollection<ProductAllergenGroup> Products { get; set; }
}