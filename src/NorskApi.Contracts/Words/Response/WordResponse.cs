using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Words.Common.Enums;
using NorskApi.Contracts.Words.Requests.Update;

namespace NorskApi.Contracts.Words.Response;

public record WordResponse(
    Guid Id,
    Guid EssayId,
    string Title,
    string Meaning,
    string EnTranslation,
    string NativeMeaning,
    WordType Type,
    PartOfSpeechTag PartOfSpeechTag,
    DifficultyLevel DifficultyLevel,
    bool IsCompleted,
    List<Guid> Synonyms,
    List<Guid> Antonyms,
    UpdateWordGrammerRequest WordGrammer,
    UpdateWordUsageExampleRequest WordUsageExample,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
