using ManagmentSystem.Application.CQRS.Customers.Queries.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Customers.Queries.Request;

public class GetAllCustomerRequest:IRequest<ResultPagination<GetAllCustomersResponse>>
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}