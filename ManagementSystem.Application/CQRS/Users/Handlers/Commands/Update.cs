using AutoMapper;
using ManagementSystem.Application.CQRS.Users.DTOs;
using ManagementSystem.Domain.Entites;
using ManagmentSystem.Common.Exceptions;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Users.Handlers.Commands;

public class Update
{
    public record struct Command : IRequest<Result<UpdateDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public sealed class Handler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<Update.Command, Result<UpdateDto>>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public async Task<Result<UpdateDto>> Handle(Update.Command request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
            if (currentUser == null) throw new BadRequestException($"`{request.Id}` user not found");
            var updatedUser = _mapper.Map<User>(request);
            _unitOfWork.UserRepository.Update(updatedUser);
            var result = _mapper.Map<UpdateDto>(updatedUser);
            return new Result<UpdateDto>
            {
                Data = result,
                Errors = [],
                IsSuccess = true
            };
        }
    }
}