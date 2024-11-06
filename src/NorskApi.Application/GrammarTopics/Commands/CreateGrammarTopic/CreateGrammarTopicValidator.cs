using System.Data;
using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.GrammarTopics.Commands.CreateGrammarTopic;

public class CreateGrammarTopicValidator : AbstractValidator<CreateGrammarTopicCommand>
{
    public CreateGrammarTopicValidator()
    {
        RuleFor(x => x.Label)
            .NotEmpty()
            .WithMessage("Label is required.")
            .MaximumLength(200)
            .WithMessage("Label must not exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required.")
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Status.ToString())
            .IsEnumName(typeof(Status), caseSensitive: false)
            .WithMessage("Invalid Status.");

        RuleFor(x => x.Chapter)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Chapter must be greater than 0.");

        RuleFor(x => x.ModuleCount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("ModuleCount must be greater than 0.");

        RuleFor(x => x.Progress)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100)
            .WithMessage("Progress must be between 0 and 100.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleFor(x => x.IsSaved).NotNull().WithMessage("IsSaved is required.");

        RuleFor(x => x.Tags).NotEmpty().WithMessage("Tags is required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");
    }
}
