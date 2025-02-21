using ManagmentSystem.Application.CQRS.Categories.Queries.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Categories.Queries.Request;

public class GetAllCategoryRequest:IRequest<ResultPagination<GetAllCategoryResponse>>
{
    public int Limit { get; set; } = 10;
    public int Page { get; set; } = 1;
}