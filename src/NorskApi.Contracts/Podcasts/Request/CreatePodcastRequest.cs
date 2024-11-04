using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Podcasts.Request;

public record CreatePodcastRequest(
    Guid? EssayId,
    string Label,
    string? Descriptions,
    string Logo,
    string Url,
    bool IsCompleted,
    bool IsFeatured,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
