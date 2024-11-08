using FluentValidation;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.GrammarRules.Command.CreateGrammarRule;

public class CreateGrammarRuleValidator : AbstractValidator<CreateGrammarRuleCommand>
{
    public CreateGrammarRuleValidator()
    {
        RuleFor(x => x.TopicId)
            .Must(x => x != Guid.Empty)
            .WithMessage("Topic Id must be a valid guid.");

        RuleFor(x => x.Label).NotEmpty().WithMessage("Label is required.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Description must not exceed 1000 characters.");

        RuleFor(x => x.ExplanatoryNotes)
            .MaximumLength(1000)
            .WithMessage("ExplanatoryNotes must not exceed 1000 characters.");

        RuleFor(x => x.SentenceStructure).NotEmpty().WithMessage("SentenceStructure is required.");

        RuleFor(x => x.RuleType).NotEmpty().WithMessage("RuleType is required.");

        RuleFor(x => x.Tags).NotEmpty().WithMessage("Tags are required.");

        RuleFor(x => x.AdditionalInformation)
            .MaximumLength(1000)
            .WithMessage("AdditionalInformation must not exceed 1000 characters.");

        RuleFor(x => x.Comments).NotEmpty().WithMessage("Comments are required.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");

        RuleFor(x => x.RelatedRuleIds)
            .Must(x => x == null || x.All(id => id != Guid.Empty))
            .WithMessage("RelatedRuleIds must be valid guids.");

        RuleForEach(x => x.Exceptions).SetValidator(new CreateExceptionCommandValidator());
        RuleForEach(x => x.ExampleOfRules).SetValidator(new CreateExampleOfRuleCommandValidator());
    }

    public class CreateExceptionCommandValidator : AbstractValidator<CreateExceptionCommand>
    {
        public CreateExceptionCommandValidator()
        {
            RuleFor(x => x.GrammarRuleId)
                .Must(x => x != Guid.Empty)
                .WithMessage("GrammarRule Id must be a valid guid.");

            RuleFor(x => x.Title)
                .MaximumLength(255)
                .WithMessage("Title must not exceed 255 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(1000)
                .WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.Comments)
                .MaximumLength(1000)
                .WithMessage("Comments must not exceed 1000 characters.");

            RuleFor(x => x.CorrectSentence)
                .MaximumLength(1000)
                .WithMessage("CorrectSentence must not exceed 1000 characters.");

            RuleFor(x => x.IncorrectSentence)
                .MaximumLength(1000)
                .WithMessage("IncorrectSentence must not exceed 1000 characters.");
        }
    }

    public class CreateExampleOfRuleCommandValidator : AbstractValidator<CreateExampleOfRuleCommand>
    {
        public CreateExampleOfRuleCommandValidator()
        {
            RuleFor(x => x.GrammarRuleId)
                .Must(x => x != Guid.Empty)
                .WithMessage("GrammarRule Id must be a valid guid.");

            RuleFor(x => x.Subjunction)
                .MaximumLength(255)
                .WithMessage("Subjunction must not exceed 255 characters.");

            RuleFor(x => x.Subject)
                .MaximumLength(255)
                .WithMessage("Subject must not exceed 255 characters.");

            RuleFor(x => x.Adverbial)
                .MaximumLength(255)
                .WithMessage("Adverbial must not exceed 255 characters.");

            RuleFor(x => x.Verb)
                .MaximumLength(255)
                .WithMessage("Verb must not exceed 255 characters.");

            RuleFor(x => x.Object)
                .MaximumLength(255)
                .WithMessage("Object must not exceed 255 characters.");

            RuleFor(x => x.Rest)
                .MaximumLength(255)
                .WithMessage("Rest must not exceed 255 characters.");

            RuleFor(x => x.CorrectSentence)
                .MaximumLength(1000)
                .WithMessage("CorrectSentence must not exceed 1000 characters.");

            RuleFor(x => x.EnglishSentence)
                .MaximumLength(1000)
                .WithMessage("EnglishSentence must not exceed 1000 characters.");

            RuleFor(x => x.IncorrectSentence)
                .MaximumLength(1000)
                .WithMessage("IncorrectSentence must not exceed 1000 characters.");
        }
    }
}
