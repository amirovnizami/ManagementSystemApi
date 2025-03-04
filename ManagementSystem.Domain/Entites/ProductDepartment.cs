namespace ManagementSystem.Domain.Entites;

public class ProductDepartment
{
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int DepartmentId { get; set; }
    public Department Department { get; set; }
}