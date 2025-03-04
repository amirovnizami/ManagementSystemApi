using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entites;

public class Product:ProductBaseEntity
{
    public List<int> IngredientsId { get; set; }
    public List<int> DepartmentsId { get; set; }
    public List<int> AllergenGroupId { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; }
    public ICollection<Department> Departments{get; set; }
    public ICollection<AllergenGroup> AllergenGroups { get; set; }
    
}