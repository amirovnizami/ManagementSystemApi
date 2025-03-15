using ManagementSystem.Domain.BaseEntities;

namespace ManagementSystem.Domain.Entites;

public class Department:BaseEntity  
{
    public string Name { get; set; }
    public ICollection<ProductDepartment> Products { get; set; }
}