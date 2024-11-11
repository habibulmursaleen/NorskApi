using NorskApi.Application.GrammarRules.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.WordAggregate.Enums;

namespace NorskApi.Application.Words.Models;

public record WordResult(
    Guid Id,
    Guid? EssayId,
    string? Title,
    string? Meaning,
    string? EnTranslation,
    string? NativeMeaning,
    WordType Type,
    PartOfSpeechTag PartOfSpeechTag,
    DifficultyLevel DifficultyLevel,
    bool IsCompleted,
    List<Guid>? Synonyms,
    List<Guid> Antonyms,
    WordGrammerResult WordGrammer,
    WordUsageExampleResult WordUsageExample,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
