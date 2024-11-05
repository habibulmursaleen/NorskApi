using ErrorOr;
using MediatR;
using NorskApi.Application.Questions.Models;
using NorskApi.Domain.Common.Enums;

namespace NorskApi.Application.Questions.Commands.UpdateQuestion;

public record UpdateQuestionCommand(
    Guid Id,
    Guid EssayId,
    string Label,
    string Answer,
    bool IsCompleted,
    DifficultyLevel DifficultyLevel
) : IRequest<ErrorOr<QuestionResult>>;
