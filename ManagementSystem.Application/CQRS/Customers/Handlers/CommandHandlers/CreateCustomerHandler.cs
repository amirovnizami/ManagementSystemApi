using ManagementSystem.Application.CQRS.Customers.Commands.Request;
using ManagementSystem.Application.CQRS.Customers.Commands.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entites;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class CreateCustomerHandler:IRequestHandler<CreateCustomerRequest, Result<CreateCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CreateCustomerResponse>> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
    {
        Customer newCustomer = new()
        {
            Name = request.Name,
            Email = request.Email
        };
        await _unitOfWork.CustomerRepository.AddAsync(newCustomer);
        CreateCustomerResponse response = new()
        {
            Id = newCustomer.Id,
            Name = newCustomer.Name,
            Email = newCustomer.Email
        };

        return new Result<CreateCustomerResponse>()
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}