namespace NorskApi.Application.Common.Interfaces.Behavior;

using ErrorOr;
using MediatR;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

public class ValidationBehavior<TRequest, TResponse> :
  IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IErrorOr
{
    private readonly IValidator<TRequest>? validator;
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        this.validator = validator;
    }
    public async Task<TResponse> Handle(
      TRequest request,
      RequestHandlerDelegate<TResponse> next,
      CancellationToken cancellationToken)
    {
        if (this.validator is not null)
        {
            var validationResult = await this.validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            var errors = validationResult.Errors.ConvertAll(fail => Error.Validation(fail.PropertyName, fail.ErrorMessage));

            return (dynamic)errors;
        }

        return await next();
    }
}