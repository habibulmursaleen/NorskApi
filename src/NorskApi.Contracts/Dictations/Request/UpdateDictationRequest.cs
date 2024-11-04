using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Dictations.Request;

public record UpdateDictationRequest(
    Guid? EssayId,
    string Label,
    string Content,
    string? Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
