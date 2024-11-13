using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Questions.Enums;

namespace NorskApi.Contracts.Questions.Request;

public record UpdateQuestionRequest(
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel
);
