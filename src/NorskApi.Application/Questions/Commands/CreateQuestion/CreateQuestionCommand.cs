using ErrorOr;
using MediatR;
using NorskApi.Application.Questions.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuestionAggregate.Enums;

namespace NorskApi.Application.Questions.Commands.CreateQuestion;

public record CreateQuestionCommand(
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    QuestionType QuestionType,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<QuestionResult>>;
