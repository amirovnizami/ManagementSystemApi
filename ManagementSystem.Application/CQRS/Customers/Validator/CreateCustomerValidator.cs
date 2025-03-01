using FluentValidation;
using ManagementSystem.Application.CQRS.Customers.Commands.Request;

namespace ManagementSystem.Application.CQRS.Customers.Validator;

public sealed class CreateCustomerValidator:AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .NotNull()
            .MaximumLength(255);
        RuleFor(c => c.Email)
            .NotEmpty()
            .MaximumLength(255)
            .EmailAddress();

    }
}