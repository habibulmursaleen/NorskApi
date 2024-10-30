using FluentValidation;
using NorskApi.Domain.LocalExpressionAggregate.Enums;

namespace NorskApi.Application.LocalExpressions.Commands.UpdateLocalExpression;

public class UpdateLocalExpressionValidator : AbstractValidator<UpdateLocalExpressionCommand>
{
    public UpdateLocalExpressionValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty().Must(x => x != Guid.Empty).WithMessage("Id must be a valid guid.");

        RuleFor(x => x.Label)
            .NotEmpty().WithMessage("Label is required.")
            .MaximumLength(200).WithMessage("Label must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.MeaningInNorsk)
            .MaximumLength(500).WithMessage("MeaningInNorsk must not exceed 500 characters.");

        RuleFor(x => x.MeaningInEnglish)
            .MaximumLength(500).WithMessage("MeaningInEnglish must not exceed 500 characters.");

        RuleFor(x => x.LocalExpressionType.ToString())
            .IsEnumName(typeof(LocalExpressionType), caseSensitive: false).WithMessage("Invalid LocalExpressionType.");
    }
}