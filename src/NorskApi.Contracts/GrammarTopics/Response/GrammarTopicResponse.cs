using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarTopics.Response;

public record GrammarTopicResponse(
    Guid Id,
    string Label,
    string Description,
    Status Status,
    double Chapter,
    double ModuleCount,
    double Progress,
    bool IsCompleted,
    bool IsSaved,
    List<GrammarTopicTagResponse> GrammarTopicTagIds,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record GrammarTopicTagResponse(Guid TagId);
