using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Essays.Models;

public record EssayResult(
    Guid Id,
    string? Logo,
    string Label,
    string? Description,
    double Progress,
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    DifficultyLevel DifficultyLevel,
    List<EssayActivityIdsResult> EssayActivityIds,
    List<EssayTagIdsResult> EssayTagIds,
    List<EssayRelatedGrammarTopicIdsResult> EssayRelatedGrammarTopicIds,
    List<ParagraphResult>? Paragraphs,
    List<RoleplayResult>? Roleplays,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record EssayActivityIdsResult(Guid ActivityId);

public record EssayTagIdsResult(Guid TagId);

public record EssayRelatedGrammarTopicIdsResult(Guid TopicId);
