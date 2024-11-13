using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Words.Common.Enums;

namespace NorskApi.Contracts.Words.Requests.Update;

public record UpdateWordRequest(
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
    List<UpdateSynonymIdRequest> WordSynonymIds,
    List<UpdateAntonymIdRequest> WordAntonymIds,
    UpdateWordGrammerRequest WordGrammer,
    UpdateWordUsageExampleRequest WordUsageExample
);

public record UpdateSynonymIdRequest(Guid WordId);

public record UpdateAntonymIdRequest(Guid WordId);
