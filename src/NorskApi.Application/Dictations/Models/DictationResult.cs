using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Dictations.Models;

public record DictationResult(
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
