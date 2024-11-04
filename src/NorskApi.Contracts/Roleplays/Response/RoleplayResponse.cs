using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Roleplays.Response;

public record RoleplayResponse(
    Guid Id,
    Guid EssayId,
    string Content,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
