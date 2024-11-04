using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Roleplays.Commands.UpdateRoleplay;

public class UpdateRoleplayValidator : AbstractValidator<UpdateRoleplayCommand>
{
    public UpdateRoleplayValidator()
    {
        RuleFor(x => x.EssayId)
            .Must(x => x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.Content)
            .NotEmpty()
            .WithMessage("Content is required.")
            .MaximumLength(500)
            .WithMessage("Content must not exceed 500 characters.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
