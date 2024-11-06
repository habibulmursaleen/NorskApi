using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.GrammarTopics.Request;

public record UpdateGrammarTopicRequest(
    Guid Id,
    string Label,
    string Description,
    Status Status,
    double Chapter,
    double ModuleCount,
    double Progress,
    bool IsCompleted,
    bool IsSaved,
    List<string> Tags,
    DifficultyLevel DifficultyLevel
);
