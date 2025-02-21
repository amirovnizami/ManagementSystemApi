using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;
public class CreateCategoryRequest:IRequest<Result<CreateCategoryResponse>>
{
    public string Name { get; set; }    
}