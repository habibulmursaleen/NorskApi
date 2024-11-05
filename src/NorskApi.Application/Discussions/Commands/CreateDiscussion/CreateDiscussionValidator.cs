using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Discussions.Commands.CreateDiscussion;

public class CreateDiscussionValidator : AbstractValidator<CreateDiscussionCommand>
{
    public CreateDiscussionValidator()
    {
        RuleFor(x => x.EssayId)
            .Must(x => x != Guid.Empty)
            .WithMessage("EssayId must be a valid guid.");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(255)
            .WithMessage("Title must not exceed 255 characters.");

        RuleFor(x => x.DiscussionEssays)
            .NotEmpty()
            .WithMessage("DiscussionEssays is required.")
            .MaximumLength(500)
            .WithMessage("DiscussionEssays must not exceed 500 characters.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");

        RuleFor(x => x.Note).MaximumLength(500).WithMessage("Note must not exceed 500 characters.");
    }
}
