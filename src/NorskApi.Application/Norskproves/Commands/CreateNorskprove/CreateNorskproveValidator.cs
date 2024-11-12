using System.Data;
using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Norskproves.Commands.CreateNorskprove;

public class CreateNorskproveValidator : AbstractValidator<CreateNorskproveCommand>
{
    public CreateNorskproveValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Label is required.")
            .MaximumLength(200)
            .WithMessage("Label must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.IsSaved).NotNull().WithMessage("IsSaved is required.");

        RuleFor(x => x.Progress)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Progress must be between 0 and 100.");

        RuleFor(x => x.TimeLimit)
            .GreaterThanOrEqualTo(0)
            .WithMessage("TimeLimit must be greater than 0.");

        RuleFor(x => x.EstimatedCompletionTime)
            .GreaterThanOrEqualTo(0)
            .WithMessage("EstimatedCompletionTime must be greater than 0.");

        RuleFor(x => x.Attempts)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Attempts must be greater than 0.");

        RuleFor(x => x.MaxScore)
            .GreaterThanOrEqualTo(0)
            .WithMessage("MaxScore must be greater than 0.");

        RuleFor(x => x.Status.ToString())
            .IsEnumName(typeof(Status), caseSensitive: false)
            .WithMessage("Invalid Status.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");

        RuleForEach(x => x.NorskproveTagIds)
            .SetValidator(new CreateNorskproveTagIdsCommandValidator());

        RuleForEach(x => x.ListeningContentIds)
            .SetValidator(new CreateListeningContentIdsCommandValidator());

        RuleForEach(x => x.ReadingContentIds)
            .SetValidator(new CreateReadingContentIdsCommandValidator());

        RuleForEach(x => x.WritingContentIds)
            .SetValidator(new CreateWritingContentIdsCommandValidator());

        RuleForEach(x => x.AdditionalGrammarTaskIds)
            .SetValidator(new CreateAdditionalGrammarTaskIdsCommandValidator());
    }
}

public class CreateNorskproveTagIdsCommandValidator : AbstractValidator<NorskproveTagIdsCommand>
{
    public CreateNorskproveTagIdsCommandValidator()
    {
        RuleFor(x => x.TagId).NotEmpty().WithMessage("TagId is required.");
    }
}

public class CreateListeningContentIdsCommandValidator
    : AbstractValidator<ListeningContentIdsCommand>
{
    public CreateListeningContentIdsCommandValidator()
    {
        RuleFor(x => x.DictationId).NotEmpty().WithMessage("DictationId is required.");
    }
}

public class CreateReadingContentIdsCommandValidator : AbstractValidator<ReadingContentIdsCommand>
{
    public CreateReadingContentIdsCommandValidator()
    {
        RuleFor(x => x.EssayId).NotEmpty().WithMessage("EssayId is required.");
    }
}

public class CreateWritingContentIdsCommandValidator : AbstractValidator<WritingContentIdsCommand>
{
    public CreateWritingContentIdsCommandValidator()
    {
        RuleFor(x => x.DiscussionId).NotEmpty().WithMessage("DiscussionId is required.");
    }
}

public class CreateAdditionalGrammarTaskIdsCommandValidator
    : AbstractValidator<AdditionalGrammarTaskIdsCommand>
{
    public CreateAdditionalGrammarTaskIdsCommandValidator()
    {
        RuleFor(x => x.TaskWorkId).NotEmpty().WithMessage("TaskWorkId is required.");
    }
}
