using AutoMapper;
using ManagmentSystem.Application.CQRS.Customers.Queries.Response;
using ManagmentSystem.Application.CQRS.Users.DTOs;
using ManagmentSystem.Application.CQRS.Users.Handlers.Commands;
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
        CreateMap<Register.Command, User>().ReverseMap();
        CreateMap<RegisterDto, User>();
        
        CreateMap<Update, Update.Command>();
        CreateMap<User, UpdateDto>();

    }
}