using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ManagementSystem.Application.Services;
using ManagementSystem.Domain.Entites;
using ManagementSystem.Repository.Common;
using ManagmentSystem.Common.Exceptions;
using ManagmentSystem.Common.GlobalResponses.Generics;
using ManagmentSystem.Common.Security;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ManagementSystem.Application.CQRS.Users.Handlers.Commands;

public class Login : IRequest<Result<string>>
{
    public class LoginRequest : IRequest<Result<string>>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

    public sealed class Handler(IUnitOfWork unitOfWork,IConfiguration configuration) : IRequestHandler<LoginRequest, Result<string>>
    {
        public async Task<Result<string>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            User user = await unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (user == null)
            {
                throw new BadRequestException("Invalid email");
            }
            var hashedPassword = PasswordHasher.ComputeStringToSha256Hash(request.Password);
            if (hashedPassword != user.PasswordHash)
            {
                throw new BadRequestException("Invalid password");
            }

            if (hashedPassword == user.PasswordHash)
            {
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role,user.UserRole.ToString())
                };
                var token = TokenService.CreateToken(authClaims,configuration);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                return new Result<string>()
                {
                    Data = tokenString
                };
            }
            return new Result<string>()
            {
                Data = "Invalid password or email"
            };
        }
    }
}