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
    List<CreateSynonymIdRequest> WordSynonymIds,
    List<CreateAntonymIdRequest> WordAntonymIds,
    CreateWordGrammerRequest WordGrammer,
    CreateWordUsageExampleRequest WordUsageExample
);

public record CreateSynonymIdRequest(Guid WordId);

public record CreateAntonymIdRequest(Guid WordId);
