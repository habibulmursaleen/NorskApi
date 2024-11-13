using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Essays.Common.Enums;

namespace NorskApi.Contracts.Essays.Requests;

public record UpdateEssayRequest(
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
    List<UpdateEssayActivityIdsRequest> EssayActivityIds,
    List<UpdateEssayTagIdsRequest> EssayTagIds,
    List<UpdateEssayRelatedGrammarTopicIdsRequest> EssayRelatedGrammarTopicIds,
    List<UpdateParagraphRequest> Paragraphs,
    List<UpdateRoleplayRequest> Roleplays
);

public record UpdateParagraphRequest(
    Guid Id,
    string Title,
    string Content,
    ContentType ContentType
);

public record UpdateRoleplayRequest(Guid Id, string Content, bool IsCompleted);

public record UpdateEssayActivityIdsRequest(Guid ActivityId);

public record UpdateEssayTagIdsRequest(Guid TagId);

public record UpdateEssayRelatedGrammarTopicIdsRequest(Guid TopicId);
