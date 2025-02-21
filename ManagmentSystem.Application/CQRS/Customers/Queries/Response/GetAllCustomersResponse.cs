namespace ManagmentSystem.Application.CQRS.Customers.Queries.Response;

public class GetAllCustomersResponse
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; }
}