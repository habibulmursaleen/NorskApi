using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Words.Common.Enums;

namespace NorskApi.Contracts.Words.Requests.Create;

public record CreateWordRequest(
    Guid EssayId,
    string Title,
    string Meaning,
    string EnTranslation,
    string NativeMeaning,
    WordType Type,
    PartOfSpeechTag PartOfSpeechTag,
    DifficultyLevel DifficultyLevel,
    bool IsCompleted,
    List<Guid> SynonymIds,
    List<Guid> AntonymIds,
    CreateWordGrammerRequest WordGrammer,
    CreateWordUsageExampleRequest WordUsageExample
);
