using FluentValidation;
using ManagmentSystem.Application.CQRS.Users.Handlers.Queries;

namespace ManagmentSystem.Application.CQRS.Users.Validator;

public class GetByEmailValidator:AbstractValidator<GetByEmail.Query>
{
    public GetByEmailValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .NotEmpty();
    }
}