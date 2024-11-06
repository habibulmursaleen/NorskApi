using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuizAggregate.Enums;

namespace NorskApi.Application.Quizes.Models;

public record QuizResult(
    Guid Id,
    Guid? EssayId,
    Guid? TopicId,
    string Question,
    string? Answer,
    bool IsRightAnswer,
    DifficultyLevel DifficultyLevel,
    QuizType QuizType,
    List<QuizOptionResult> Options,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
