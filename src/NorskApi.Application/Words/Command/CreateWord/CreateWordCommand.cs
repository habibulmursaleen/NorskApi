using ErrorOr;
using MediatR;
using NorskApi.Application.Words.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.WordAggregate.Enums;

namespace NorskApi.Application.Words.Command.CreateWord;

public record CreateWordCommand(
    Guid? EssayId,
    string Title,
    string Meaning,
    string EnTranslation,
    string NativeMeaning,
    WordType Type,
    PartOfSpeechTag PartOfSpeechTag,
    DifficultyLevel DifficultyLevel,
    bool IsCompleted,
    List<WordSynonymeIdCommand> WordSynonymIds,
    List<WordAntonymeIdCommand> WordAntonymIds,
    CreateWordUsageExampleCommand? WordUsageExample,
    CreateWordGrammerCommand? WordGrammer
) : IRequest<ErrorOr<WordResult>>;

public record CreateWordUsageExampleCommand(
    string? CorrectSentence,
    string? IncorrectSentence,
    string? EnglishSentence,
    string? NewSentence
);

public record CreateWordGrammerCommand(
    string? GenderMasculine,
    string? GenderFeminine,
    string? GenderNeutral,
    string? SingularDefinitiv,
    string? SingularIndefinitiv,
    string? PluralDefinitiv,
    string? PluralIndefinitiv,
    string? Infinitiv,
    string? PresentTense,
    string? PastTense,
    string? PresentPerfectTense,
    string? FutureTense,
    string? Positive,
    string? Comparative,
    string? Superlative,
    string? SuperlativeDetermined,
    string? PastParticiple,
    string? PresentParticiple,
    bool? Irregular,
    bool? StrongVerb,
    bool? WeakVerb
);

public record WordSynonymeIdCommand(Guid WordId);

public record WordAntonymeIdCommand(Guid WordId);
