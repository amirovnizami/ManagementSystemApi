using System.Globalization;
using FluentValidation;
using MediatR;

namespace ManagementSystem.Application.PipelineBehaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> compositValidator)
    {
        _validators = compositValidator;
    }

    static ValidationPipelineBehaviour()
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("az");
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var result = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = result.SelectMany(r => r.Errors).Where(f => f != null).ToList();
        if (failures.Any())
        {
            throw new FluentValidation.ValidationException(failures);
        }

        return await next();
    }
}