using System.ComponentModel.DataAnnotations;
using ManagmentSystem.Application.CQRS.Customers.Commands.Response;
using ManagmentSystem.Common.GlobalResponses;
using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Customers.Commands.Request;

public class UpdateCustomerRequest:IRequest<Result<UpdateCustomerResponse>>
{
    [Required]
    public int CustomerId { get; set; } 
    public string? Name { get; set; }
    public string? Email { get; set; }
}