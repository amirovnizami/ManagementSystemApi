using AutoMapper;
using FluentValidation;
using ManagementSystem.Application.CQRS.Users.DTOs;
using ManagementSystem.Domain.Entites;
using ManagmentSystem.Common.Exceptions;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Common.Security;
using ManagementSystem.Repository.Common;
using MediatR;

namespace ManagementSystem.Application.CQRS.Users.Handlers.Commands;

public class Register
{
    public record struct RegisterCommand : IRequest<Result<RegisterDto>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    public sealed class Handler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<RegisterCommand> validator) : IRequestHandler<RegisterCommand, Result<RegisterDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly IValidator<RegisterCommand> _validator = validator;

        public async Task<Result<RegisterDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
         
            
            var isExist = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (isExist != null) throw new BadRequestException("User already exists");

            var newUser = _mapper.Map<User>(request);

            var hashPass = PasswordHasher.ComputeStringToSha256Hash(request.Password);
            newUser.PasswordHash = hashPass;

            await _unitOfWork.UserRepository.RegisterAsync(newUser);
            var response = _mapper.Map<RegisterDto>(newUser);
            return new Result<RegisterDto> { Data = response, Errors = [], IsSuccess = true };
        }
    }
}