using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;

namespace NorskApi.Application.Essays.Models;

public record EssayResult(
    Guid Id,
    string? Logo,
    string Label,
    string? Description,
    double Progress,
    List<string>? Activities,
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    List<string>? Tags,
    DifficultyLevel DifficultyLevel,
    List<TopicId>? RelatedGrammarTopicIds,
    List<ParagraphResult>? Paragraphs,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
