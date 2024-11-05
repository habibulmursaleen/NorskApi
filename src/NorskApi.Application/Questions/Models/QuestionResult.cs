using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Questions.Models;

public record QuestionResult(
    Guid Id,
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
