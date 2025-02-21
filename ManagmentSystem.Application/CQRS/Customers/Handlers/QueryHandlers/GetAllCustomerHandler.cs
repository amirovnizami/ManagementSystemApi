using AutoMapper;
using ManagmentSystem.Application.CQRS.Customers.Queries.Request;
using ManagmentSystem.Application.CQRS.Customers.Queries.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Domain.Entites;
using ManagmentSystem.Repository.Common;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Customers.Handlers.QueryHandlers;

public class GetAllCustomerHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllCustomerRequest, ResultPagination<GetAllCustomersResponse>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<ResultPagination<GetAllCustomersResponse>> Handle(GetAllCustomerRequest request,
        CancellationToken cancellationToken)
    {
        var customers = _unitOfWork.CustomerRepository.GetAll();
    
        var totalCount = customers.Count(); 

        var paginatedCustomers = customers.Skip((request.Page - 1) * request.Limit)
            .Take(request.Limit)
            .ToList();

        var responseList = _mapper.Map<List<GetAllCustomersResponse>>(paginatedCustomers);

        var result = new ResultPagination<GetAllCustomersResponse>
        {
            Data = new Pagination<GetAllCustomersResponse>
            {
                Data = responseList,
                TotalDataCount = totalCount,
                IsSuccess = true
            }
        };

        return result;
    }

}
