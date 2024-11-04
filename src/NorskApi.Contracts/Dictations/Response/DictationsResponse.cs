using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Dictations.Response;

public record DictationResponse(
    Guid Id,
    Guid? EssayId,
    string Label,
    string Content,
    string? Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
