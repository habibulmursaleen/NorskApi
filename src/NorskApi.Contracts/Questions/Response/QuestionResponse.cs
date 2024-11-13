using NorskApi.Contracts.Common.Enums;
using NorskApi.Contracts.Questions.Enums;

namespace NorskApi.Contracts.Questions.Response;

public record QuestionResponse(
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
