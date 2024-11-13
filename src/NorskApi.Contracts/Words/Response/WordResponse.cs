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
    List<SynonymIdResponse> WordSynonymeIds,
    List<AntonymIdResponse> WordAntonymeIds,
    WordGrammarResponse WordGrammer,
    WordUseageExampleResponse WordUsageExample,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record SynonymIdResponse(Guid WordId);

public record AntonymIdResponse(Guid WordId);
