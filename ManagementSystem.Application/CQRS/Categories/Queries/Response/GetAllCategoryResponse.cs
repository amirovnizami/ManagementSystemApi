namespace ManagementSystem.Application.CQRS.Categories.Queries.Response;

public class GetAllCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? Createdby { get; set; }
}