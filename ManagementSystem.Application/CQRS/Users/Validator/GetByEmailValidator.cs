using FluentValidation;
using ManagementSystem.Application.CQRS.Users.Handlers.Queries;

namespace ManagementSystem.Application.CQRS.Users.Validator;

public class GetByEmailValidator:AbstractValidator<GetByEmail.Query>
{
    public GetByEmailValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
    }
}