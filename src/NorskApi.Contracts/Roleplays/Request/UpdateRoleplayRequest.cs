using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Roleplays.Request;

public record UpdateRoleplayRequest(
    Guid EssayId,
    string Content,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
);
