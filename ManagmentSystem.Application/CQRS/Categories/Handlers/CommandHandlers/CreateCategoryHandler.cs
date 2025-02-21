using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Domain.Entites;
using ManagmentSystem.Repository.Common;
using MediatR;

namespace ManagmentSystem.Application.CQRS.Categories.Handlers.CommandHandlers;

public class CreateCategoryHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryRequest, Result<CreateCategoryResponse>>
{

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        Category newCategory = new()
        {
            Name = request.Name
        };

        if (string.IsNullOrEmpty(newCategory.Name))
        {
            return new Result<CreateCategoryResponse>
            {
                Data = null,
                Errors = ["Categoriyanin adi null ve ya bosh ola bilmez"],
                IsSuccess = false
            };
        }

        await _unitOfWork.CategoryRepository.AddAsync(newCategory);

        CreateCategoryResponse response = new()
        {
            Id = newCategory.Id,
            Name = request.Name,
        };

        return new Result<CreateCategoryResponse>
        {
            Data = response,
            Errors = [],
            IsSuccess = true
        };
    }
}