using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Quizes.Common.Enums;

namespace NorskApi.Contracts.Quizs.Response;

public record QuizResponse(
    Guid Id,
    Guid? EssayId,
    Guid? TopicId,
    Guid? DictationId,
    string Question,
    string? Answer,
    bool IsRightAnswer,
    DifficultyLevel DifficultyLevel,
    QuizType QuizType,
    List<QuizOptionResponse> Options,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record QuizOptionResponse(
    Guid Id,
    string Title,
    bool IsCorrect,
    bool? MultipleChoiceAnswer,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);
