using ManagmentSystem.Application.CQRS.Customers.Commands.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Customers.Commands.Request;

public class CreateCustomerRequest : IRequest<Result<CreateCustomerResponse>>
{
    public string Name { get; set; }
    public string Email { get; set; }
}