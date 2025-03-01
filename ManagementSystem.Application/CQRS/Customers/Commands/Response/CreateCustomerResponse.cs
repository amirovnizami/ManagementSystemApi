namespace ManagementSystem.Application.CQRS.Customers.Commands.Response;

public class CreateCustomerResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}