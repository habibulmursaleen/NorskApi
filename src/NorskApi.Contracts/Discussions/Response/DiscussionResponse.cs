using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Discussions.Response;

public record DiscussionResponse(
    Guid Id,
    Guid EssayId,
    string Title,
    string DiscussionEssays,
    string Note,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);