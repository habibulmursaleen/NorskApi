using FluentValidation;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.EssayAggregate.Enums;

namespace NorskApi.Application.Essays.Command.CreateEssay;

public class CreateEssayValidator : AbstractValidator<CreateEssayCommand>
{
    public CreateEssayValidator()
    {
        RuleFor(x => x.Logo)
            .Must(x => string.IsNullOrEmpty(x) || Uri.IsWellFormedUriString(x, UriKind.Absolute))
            .WithMessage("Logo must be a valid URL or Base64 string.");

        RuleFor(x => x.Label).NotEmpty().WithMessage("Label is required.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Description must not exceed 1000 characters.");

        RuleFor(x => x.Progress)
            .InclusiveBetween(0, 100)
            .WithMessage("Progress must be between 0 and 100.");

        RuleFor(x => x.Status.ToString())
            .IsEnumName(typeof(Status), caseSensitive: false)
            .WithMessage("Invalid Status.");

        RuleFor(x => x.Notes).NotEmpty().WithMessage("Notes are required.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.IsSaved).NotNull().WithMessage("IsSaved is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");

        RuleForEach(x => x.EssayActivityIds)
            .SetValidator(new CreateEssayActivityIdsCommandValidator());
        RuleForEach(x => x.EssayTagIds).SetValidator(new CreateEssayTagIdsCommandValidator());
        RuleForEach(x => x.EssayRelatedGrammarTopicIds)
            .SetValidator(new CreateEssayRelatedGrammarTopicIdsCommandValidator());
        RuleForEach(x => x.Paragraphs).SetValidator(new CreateParagraphCommandValidator());
        RuleForEach(x => x.Roleplays).SetValidator(new CreateRoleplaysCommandValidator());
    }

    public class CreateParagraphCommandValidator : AbstractValidator<CreateParagraphCommand>
    {
        public CreateParagraphCommandValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(255)
                .WithMessage("Title must not exceed 255 characters.");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required.")
                .MaximumLength(500)
                .WithMessage("Content must not exceed 500 characters.");

            RuleFor(x => x.ContentType.ToString())
                .IsEnumName(typeof(ContentType), caseSensitive: false)
                .WithMessage("Invalid ContentType.");
        }
    }

    public class CreateRoleplaysCommandValidator : AbstractValidator<CreateRoleplayCommand>
    {
        public CreateRoleplaysCommandValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content is required.")
                .MaximumLength(500)
                .WithMessage("Content must not exceed 500 characters.");

            RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");
        }
    }

    public class CreateEssayActivityIdsCommandValidator
        : AbstractValidator<CreateEssayActivityIdsCommand>
    {
        public CreateEssayActivityIdsCommandValidator()
        {
            RuleFor(x => x.ActivityId).NotEmpty().WithMessage("ActivityId is required.");
        }
    }

    public class CreateEssayTagIdsCommandValidator : AbstractValidator<CreateEssayTagIdsCommand>
    {
        public CreateEssayTagIdsCommandValidator()
        {
            RuleFor(x => x.TagId).NotEmpty().WithMessage("TagId is required.");
        }
    }

    public class CreateEssayRelatedGrammarTopicIdsCommandValidator
        : AbstractValidator<CreateEssayRelatedGrammarTopicIdsCommand>
    {
        public CreateEssayRelatedGrammarTopicIdsCommandValidator()
        {
            RuleFor(x => x.TopicId).NotEmpty().WithMessage("TopicId is required.");
        }
    }
}
