using System.Data;
using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Dictations.Commands.CreateDictation;

public class CreateDictationValidator : AbstractValidator<CreateDictationCommand>
{
    public CreateDictationValidator()
    {
        RuleFor(x => x.EssayId)
            .Must(x => x == null || x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.Label)
            .NotNull()
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Label is required with max 255 character.");

        RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.Answer).MaximumLength(500).WithMessage("Answer is required.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
