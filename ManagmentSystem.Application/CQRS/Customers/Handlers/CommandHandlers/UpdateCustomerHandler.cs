using ManagmentSystem.Application.CQRS.Customers.Commands.Request;
using ManagmentSystem.Application.CQRS.Customers.Commands.Response;
using ManagmentSystem.Common.GlobalResponses;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Repository.Common;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Customers.Handlers.CommandHandlers;

public class UpdateCustomerHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCustomerRequest, Result<UpdateCustomerResponse>>
{
    public readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<UpdateCustomerResponse>> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        var currentCustomer =  await _unitOfWork.CustomerRepository.GetByIdAsync(request.CustomerId);
        currentCustomer.Name = request.Name;
        currentCustomer.Email = request.Email;
        currentCustomer.UpdatedDate = DateTime.Now;
        
        _unitOfWork.CustomerRepository.Update(currentCustomer);

        UpdateCustomerResponse response = new UpdateCustomerResponse
        {
            Name = currentCustomer.Name,
            Email = currentCustomer.Email,
            UpdatedDate = currentCustomer.UpdatedDate
        };
        return new Result<UpdateCustomerResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}