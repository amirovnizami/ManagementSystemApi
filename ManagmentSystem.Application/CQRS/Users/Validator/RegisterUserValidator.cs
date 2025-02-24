using FluentValidation;
using ManagmentSystem.Application.CQRS.Users.Handlers.Commands;

namespace ManagmentSystem.Application.CQRS.Users.Validator;

public class RegisterUserValidator : AbstractValidator<Register.Command>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is invalid");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty, null, or whitespace")
            .MaximumLength(70);

        RuleFor(x => x.Surname)
            .NotEmpty().WithMessage("Surname cannot be empty, null, or whitespace")
            .MaximumLength(25);

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone number cannot be empty, null, or whitespace")
            .Matches(@"^\+994(5[015]|7[07])\d{7}$")
            .WithMessage("Mobile phone format is +994");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long");
    }
}