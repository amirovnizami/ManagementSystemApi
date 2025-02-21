using ManagmentSystem.Application.CQRS.Categories.Queries.Request;
using ManagmentSystem.Application.CQRS.Categories.Queries.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Repository.Common;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Categories.Handlers.QueryHandlers;

public class GetAllCategoryQuery(IUnitOfWork unitOfWork)
    : IRequestHandler<GetAllCategoryRequest, ResultPagination<GetAllCategoryResponse>>
{
    private readonly IUnitOfWork _UnitOfWork = unitOfWork;

    public async Task<ResultPagination<GetAllCategoryResponse>> Handle(GetAllCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var categories = _UnitOfWork.CategoryRepository.GetAll();
        var totalCount = categories.Count();
        categories = categories.Skip((request.Page -1 ) * request.Limit).Take(request.Limit);
        var mappedCategories = new List<GetAllCategoryResponse>();
        foreach (var category in categories)
        {
            var mapped = new GetAllCategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Createdby = category.CreatedBy,
                CreatedDate = category.CreatedDate,
            };
            mappedCategories.Add(mapped);
        }

        return new ResultPagination<GetAllCategoryResponse>
        {
            Data = new Pagination<GetAllCategoryResponse>
            {
                Data = mappedCategories,
                TotalDataCount = totalCount,
                IsSuccess = true
            }
        };
    }
}