using AutoMapper;
using ManagementSystem.Application.CQRS.Customers.Queries.Response;
using ManagementSystem.Application.CQRS.Users.DTOs;
using ManagementSystem.Application.CQRS.Users.Handlers.Commands;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Domain.Entites;
using ManagmentSystem.Domain.Entites;

namespace ManagementSystem.Application.AutoMapper;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCategoryRequest , Category>().ReverseMap();
        CreateMap<Category, CreateCategoryResponse>();
        CreateMap<GetAllCustomersResponse, Customer>().ReverseMap();
        CreateMap<ResultPagination<Customer>, GetAllCustomersResponse>().ReverseMap();
        CreateMap<Register.Command, User>().ReverseMap();
        CreateMap<RegisterDto, User>();
        
        CreateMap<Update, Update.Command>();
        CreateMap<User, UpdateDto>();

    }
}