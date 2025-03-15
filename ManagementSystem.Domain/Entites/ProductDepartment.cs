using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementSystem.Domain.Entites;

public class ProductDepartment
{
    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }
    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public Product Product { get; set; }
    public Department Department { get; set; }
}