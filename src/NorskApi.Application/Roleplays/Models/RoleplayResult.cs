using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Roleplays.Models;

public record RoleplayResult(
    Guid Id,
    Guid EssayId,
    string Content,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
