using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.TaskWorks.Response;

public record TaskWorkResponse(
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
