using System.Data;
using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Norskproves.Commands.UpdateNorskprove;

public class UpdateNorskproveValidator : AbstractValidator<UpdateNorskproveCommand>
{
    public UpdateNorskproveValidator()
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
            .SetValidator(new UpdateNorskproveTagIdsCommandValidator());

        RuleForEach(x => x.ListeningContentIds)
            .SetValidator(new UpdateListeningContentIdsCommandValidator());

        RuleForEach(x => x.ReadingContentIds)
            .SetValidator(new UpdateReadingContentIdsCommandValidator());

        RuleForEach(x => x.WritingContentIds)
            .SetValidator(new UpdateWritingContentIdsCommandValidator());

        RuleForEach(x => x.AdditionalGrammarTaskIds)
            .SetValidator(new UpdateAdditionalGrammarTaskIdsCommandValidator());
    }
}

public class UpdateNorskproveTagIdsCommandValidator : AbstractValidator<NorskproveTagIdsCommand>
{
    public UpdateNorskproveTagIdsCommandValidator()
    {
        RuleFor(x => x.TagId).NotEmpty().WithMessage("TagId is required.");
    }
}

public class UpdateListeningContentIdsCommandValidator
    : AbstractValidator<ListeningContentIdsCommand>
{
    public UpdateListeningContentIdsCommandValidator()
    {
        RuleFor(x => x.DictationId).NotEmpty().WithMessage("DictationId is required.");
    }
}

public class UpdateReadingContentIdsCommandValidator : AbstractValidator<ReadingContentIdsCommand>
{
    public UpdateReadingContentIdsCommandValidator()
    {
        RuleFor(x => x.EssayId).NotEmpty().WithMessage("EssayId is required.");
    }
}

public class UpdateWritingContentIdsCommandValidator : AbstractValidator<WritingContentIdsCommand>
{
    public UpdateWritingContentIdsCommandValidator()
    {
        RuleFor(x => x.DiscussionId).NotEmpty().WithMessage("DiscussionId is required.");
    }
}

public class UpdateAdditionalGrammarTaskIdsCommandValidator
    : AbstractValidator<AdditionalGrammarTaskIdsCommand>
{
    public UpdateAdditionalGrammarTaskIdsCommandValidator()
    {
        RuleFor(x => x.TaskWorkId).NotEmpty().WithMessage("TaskWorkId is required.");
    }
}
