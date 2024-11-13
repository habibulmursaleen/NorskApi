using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Essays.Common.Enums;

namespace NorskApi.Contracts.Essays.Response;

public record EssayResponse(
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
    List<EssayActivityIdsResponse> EssayActivityIds,
    List<EssayTagIdsResponse> EssayTagIds,
    List<EssayRelatedGrammarTopicIdsResponse> EssayRelatedGrammarTopicIds,
    List<ParagraphResponse> Paragraphs,
    List<RoleplayResponse> Roleplays,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record ParagraphResponse(
    Guid Id,
    string Title,
    string Content,
    ContentType ContentType,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record RoleplayResponse(
    Guid Id,
    string Content,
    bool IsCompleted,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record EssayActivityIdsResponse(Guid ActivityId);

public record EssayTagIdsResponse(Guid TagId);

public record EssayRelatedGrammarTopicIdsResponse(Guid TopicId);

public record EssayLiteResponse(
    Guid Id,
    string Logo,
    string Label,
    string Description,
    double Progress,
    bool IsCompleted,
    bool IsSaved,
    Status Status,
    DifficultyLevel DifficultyLevel,
    List<EssayActivityIdsResponse> EssayActivityIds,
    List<EssayTagIdsResponse> EssayTagIds,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
