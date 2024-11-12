using FluentValidation;
using NorskApi.Application.Words.Command.CreateWord;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.WordAggregate.Enums;

namespace NorskApi.Application.Words.Command.UpdateWord;

public class UpdateWordValidator : AbstractValidator<UpdateWordCommand>
{
    public UpdateWordValidator()
    {
        RuleFor(x => x.EssayId)
            .Must(x => x != Guid.Empty || x == null)
            .WithMessage("Essay Id must be a valid guid.");

        RuleFor(x => x.Title).MaximumLength(255).WithMessage("Title is required.");

        RuleFor(x => x.Meaning).MaximumLength(255).WithMessage("Meaning is required.");

        RuleFor(x => x.EnTranslation).MaximumLength(255).WithMessage("EnTranslation is required.");

        RuleFor(x => x.NativeMeaning).MaximumLength(255).WithMessage("NativeMeaning is required.");

        RuleFor(x => x.Type.ToString())
            .IsEnumName(typeof(WordType), caseSensitive: false)
            .WithMessage("Invalid WordType.");

        RuleFor(x => x.PartOfSpeechTag.ToString())
            .IsEnumName(typeof(PartOfSpeechTag), caseSensitive: false)
            .WithMessage("Invalid PartOfSpeechTag.");

        RuleFor(x => x.DifficultyLevel.ToString())
            .IsEnumName(typeof(DifficultyLevel), caseSensitive: false)
            .WithMessage("Invalid DifficultyLevel.");

        RuleFor(x => x.IsCompleted).NotNull().WithMessage("IsCompleted is required.");

        RuleForEach(x => x.WordSynonymIds)
            .SetValidator(new UpdateWordSynonymeIdsCommandValidator());

        RuleForEach(x => x.WordAntonymIds)
            .SetValidator(new UpdateWordAntonymeIdsCommandValidator());

        RuleFor(x => x.WordUsageExample)
            .SetValidator(
                new UpdateWordUsageExampleCommandValidator()
                    as IValidator<UpdateWordUsageExampleCommand?>
            );

        RuleFor(x => x.WordUsageExample)
            .SetValidator(
                new UpdateWordUsageExampleCommandValidator()
                    as IValidator<UpdateWordUsageExampleCommand?>
            );
    }
}

public class UpdateWordGrammerCommandValidator : AbstractValidator<UpdateWordGrammerCommand>
{
    public UpdateWordGrammerCommandValidator()
    {
        RuleFor(x => x.GenderMasculine)
            .MaximumLength(255)
            .WithMessage("GenderMasculine must not exceed 255 characters.");

        RuleFor(x => x.GenderFeminine)
            .MaximumLength(255)
            .WithMessage("GenderFeminine must not exceed 255 characters.");

        RuleFor(x => x.GenderNeutral)
            .MaximumLength(255)
            .WithMessage("GenderNeuter must not exceed 255 characters.");

        RuleFor(x => x.SingularDefinitiv)
            .MaximumLength(255)
            .WithMessage("SingularDefinitiv must not exceed 255 characters.");

        RuleFor(x => x.SingularIndefinitiv)
            .MaximumLength(255)
            .WithMessage("SingularIndefinitiv must not exceed 255 characters.");

        RuleFor(x => x.PluralDefinitiv)
            .MaximumLength(255)
            .WithMessage("PluralDefinitiv must not exceed 255 characters.");

        RuleFor(x => x.PluralIndefinitiv)
            .MaximumLength(255)
            .WithMessage("PluralIndefinitiv must not exceed 255 characters.");

        RuleFor(x => x.Infinitiv)
            .MaximumLength(255)
            .WithMessage("Infinitiv must not exceed 255 characters.");

        RuleFor(x => x.PresentTense)
            .MaximumLength(255)
            .WithMessage("PresentTense must not exceed 255 characters.");

        RuleFor(x => x.PastTense)
            .MaximumLength(255)
            .WithMessage("PastTense must not exceed 255 characters.");

        RuleFor(x => x.PresentPerfectTense)
            .MaximumLength(255)
            .WithMessage("PresentPerfectTense must not exceed 255 characters.");

        RuleFor(x => x.FutureTense)
            .MaximumLength(255)
            .WithMessage("FutureTense must not exceed 255 characters.");

        RuleFor(x => x.Positive)
            .MaximumLength(255)
            .WithMessage("Positive must not exceed 255 characters.");

        RuleFor(x => x.Comparative)
            .MaximumLength(255)
            .WithMessage("Comparative must not exceed 255 characters.");

        RuleFor(x => x.Superlative)
            .MaximumLength(255)
            .WithMessage("Superlative must not exceed 255 characters.");

        RuleFor(x => x.SuperlativeDetermined)
            .MaximumLength(255)
            .WithMessage("SuperlativeDetermined must not exceed 255 characters.");

        RuleFor(x => x.PastParticiple)
            .MaximumLength(255)
            .WithMessage("PastParticiple must not exceed 255 characters.");

        RuleFor(x => x.PresentParticiple)
            .MaximumLength(255)
            .WithMessage("PresentParticiple must not exceed 255 characters.");

        RuleFor(x => x.Irregular).NotNull().WithMessage("Irregular is required.");

        RuleFor(x => x.StrongVerb).NotNull().WithMessage("StrongVerb is required.");

        RuleFor(x => x.WeakVerb).NotNull().WithMessage("WeakVerb is required.");
    }
}

public class UpdateWordUsageExampleCommandValidator
    : AbstractValidator<UpdateWordUsageExampleCommand>
{
    public UpdateWordUsageExampleCommandValidator()
    {
        RuleFor(x => x.CorrectSentence)
            .MaximumLength(1000)
            .WithMessage("CorrectSentence must not exceed 1000 characters.");

        RuleFor(x => x.IncorrectSentence)
            .MaximumLength(1000)
            .WithMessage("IncorrectSentence must not exceed 1000 characters.");

        RuleFor(x => x.EnglishSentence)
            .MaximumLength(1000)
            .WithMessage("EnglishSentence must not exceed 1000 characters.");

        RuleFor(x => x.NewSentence)
            .MaximumLength(255)
            .WithMessage("Rest must not exceed 255 characters.");
    }
}

public class UpdateWordSynonymeIdsCommandValidator : AbstractValidator<WordSynonymeIdCommand>
{
    public UpdateWordSynonymeIdsCommandValidator()
    {
        RuleFor(x => x.WordId)
            .Must(x => x != Guid.Empty)
            .WithMessage("WordId must be a valid guid.");
    }
}

public class UpdateWordAntonymeIdsCommandValidator : AbstractValidator<WordAntonymeIdCommand>
{
    public UpdateWordAntonymeIdsCommandValidator()
    {
        RuleFor(x => x.WordId)
            .Must(x => x != Guid.Empty)
            .WithMessage("WordId must be a valid guid.");
    }
}
