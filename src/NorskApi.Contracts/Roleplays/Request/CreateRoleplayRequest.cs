using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Roleplays.Request;

public record CreateRoleplayRequest(
    Guid EssayId,
    string Content,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
);
