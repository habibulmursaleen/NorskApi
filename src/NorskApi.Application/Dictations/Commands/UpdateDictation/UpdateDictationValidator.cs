using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Dictations.Commands.UpdateDictation;

public class UpdateDictationValidator : AbstractValidator<UpdateDictationCommand>
{
    public UpdateDictationValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEmpty()
            .Must(x => x != Guid.Empty)
            .WithMessage("Id must be a valid guid.");

        RuleFor(x => x.EssayId)
            .Must(x => x == null || x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.Label)
            .MaximumLength(255)
            .NotNull()
            .NotEmpty()
            .WithMessage("Label is required with 255 character.");

        RuleFor(x => x.Content).NotNull().NotEmpty().WithMessage("Content is required.");

        RuleFor(x => x.Answer).MaximumLength(500).WithMessage("Answer is required.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
