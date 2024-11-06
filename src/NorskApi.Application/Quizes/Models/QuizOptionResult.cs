namespace NorskApi.Application.Quizes.Models;

public record QuizOptionResult(
    Guid Id,
    string Title,
    bool IsCorrect,
    bool? MultipleChoiceAnswer,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
