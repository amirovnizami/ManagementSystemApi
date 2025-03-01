namespace ManagementSystem.Application.CQRS.Customers.Commands.Response;

public class UpdateCustomerResponse
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime ?UpdatedDate { get; set; }
}