using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.TaskWorks.Models;

public record TaskWorkResult(
    Guid Id,
    Guid TopicId,
    string? Logo,
    string Label,
    string? TaskPointer,
    bool IsCompleted,
    string? Answer,
    string? Comments,
    string? AdditionalInfo,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
