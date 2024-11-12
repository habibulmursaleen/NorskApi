using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarTopics.Request;

public record CreateGrammarTopicRequest(
    string Label,
    string Description,
    Status Status,
    double Chapter,
    double ModuleCount,
    double Progress,
    bool IsCompleted,
    bool IsSaved,
    List<CreateGrammarTopicTagRequest> GrammarTopicTagIds,
    DifficultyLevel DifficultyLevel
);

public record CreateGrammarTopicTagRequest(Guid TagId);
