using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Questions.Response;

public record QuestionResponse(
    Guid Id,
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
