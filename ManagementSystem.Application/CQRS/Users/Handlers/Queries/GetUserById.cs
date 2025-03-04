using ManagementSystem.Application.CQRS.Users.DTOs;
using ManagementSystem.Repository.Common;
using ManagmentSystem.Common.Exceptions;
using ManagmentSystem.Common.GlobalResponses.Generics;
using MediatR;

namespace ManagementSystem.Application.CQRS.Users.Handlers.Queries;

public class GetUserById
{
    public record struct Query : IRequest<Result<UserDto>>
    {
        public int Id { get; set; }
    }
}
public   class GetUserByIdHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserById.Query, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserById.Query request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user == null)
        {
            throw new BadRequestException("User not found");
        }

        var response = new UserDto()
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name
        };

        return new Result<UserDto>()
        {
            Data = response,
            IsSuccess = true,
            Errors = []
        };
    }
}