using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.GrammarTopics.Models;

public record GrammarTopicResult(
    Guid Id,
    string Label,
    string Description,
    Status Status,
    double Chapter,
    double ModuleCount,
    double Progress,
    bool IsCompleted,
    bool IsSaved,
    List<GrammarTopicTagResult> GrammarTopicTagIds,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record GrammarTopicTagResult(Guid TagId);
