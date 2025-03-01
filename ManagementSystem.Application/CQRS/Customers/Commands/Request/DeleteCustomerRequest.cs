using ManagementSystem.Application.CQRS.Customers.Commands.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Commands.Request;

public class DeleteCustomerRequest:IRequest
{
    public int CustomerId { get; set; }
}