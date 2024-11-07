using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Quizes.Common.Enums;

namespace NorskApi.Contracts.Quizes.Requests;

public record UpdateQuizRequest(
    Guid? EssayId,
    Guid? TopicId,
    string Question,
    string? Answer,
    bool IsRightAnswer,
    DifficultyLevel DifficultyLevel,
    QuizType QuizType,
    List<UpdateQuizOptionRequest> Options
);
