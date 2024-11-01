using NorskApi.Domain.Common.Enums;
namespace NorskApi.Application.Discussions.Models;

public record DiscussionResult(
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
