using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Essays.Common.Enums;

namespace NorskApi.Contracts.Essays.Requests;

public record CreateEssayRequest(
    string? Logo,
    string Label,
    string? Description,
    double Progress,
    Status Status,
    string Notes,
    bool IsCompleted,
    bool IsSaved,
    DifficultyLevel DifficultyLevel,
    List<CreateEssayActivityIdsRequest> EssayActivityIds,
    List<CreateEssayTagIdsRequest> EssayTagIds,
    List<CreateEssayRelatedGrammarTopicIdsRequest> EssayRelatedGrammarTopicIds,
    List<CreateParagraphRequest> Paragraphs,
    List<CreateRoleplayRequest> Roleplays
);

public record CreateParagraphRequest(string Title, string Content, ContentType ContentType);

public record CreateRoleplayRequest(string Content, bool IsCompleted);

public record CreateEssayActivityIdsRequest(Guid ActivityId);

public record CreateEssayTagIdsRequest(Guid TagId);

public record CreateEssayRelatedGrammarTopicIdsRequest(Guid TopicId);
