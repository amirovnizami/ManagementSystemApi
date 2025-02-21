using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;


public class CreateCategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}