using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Podcasts.Models;

public record PodcastResult(
    Guid Id,
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
