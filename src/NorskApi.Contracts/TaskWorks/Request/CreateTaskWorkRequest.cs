using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.TaskWorks.Request;

public record CreateTaskWorkRequest(
    Guid TopicId,
    string? Logo,
    string Label,
    string? TaskPointer,
    bool IsCompleted,
    string? Answer,
    string? Comments,
    string? AdditionalInfo,
    DifficultyLevel DifficultyLevel
);
