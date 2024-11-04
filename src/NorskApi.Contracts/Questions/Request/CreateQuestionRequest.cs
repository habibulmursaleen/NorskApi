using NorskApi.Contracts.Common.Enums;

namespace NorskApi.Contracts.Questions.Request;

public record CreateQuestionRequest(
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
);
