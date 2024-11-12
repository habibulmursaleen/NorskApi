using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuestionAggregate.Enums;

namespace NorskApi.Application.Questions.Models;

public record QuestionResult(
    Guid Id,
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
