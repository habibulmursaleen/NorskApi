using FluentValidation;

namespace NorskApi.Application.LocalExpressions.Commands.DeleteLocalExpression;

public class DeleteLocalExpressionValidator : AbstractValidator<DeleteLocalExpressionCommand>
{
    public DeleteLocalExpressionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().Must(x => x != Guid.Empty).WithMessage("Id must be a valid guid.");
    }
}