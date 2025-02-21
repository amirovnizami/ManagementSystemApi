using AutoMapper;
using ManagmentSystem.Application.CQRS.Customers.Queries.Response;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Domain.Entites;

namespace ManagmentSystem.Application.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryRequest , Category>().ReverseMap();
        CreateMap<Category, CreateCategoryResponse>();
        CreateMap<GetAllCustomersResponse, Customer>().ReverseMap();
        CreateMap<ResultPagination<Customer>, GetAllCustomersResponse>().ReverseMap();

    }
}