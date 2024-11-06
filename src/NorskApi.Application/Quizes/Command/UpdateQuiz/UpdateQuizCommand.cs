using ErrorOr;
using MediatR;
using NorskApi.Application.Quizes.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuizAggregate.Entites;
using NorskApi.Domain.QuizAggregate.Enums;

namespace NorskApi.Application.Quizes.Command.UpdateQuiz;

public record UpdateQuizCommand(
    Guid Id,
    Guid? EssayId,
    Guid? TopicId,
    string Question,
    string? Answer,
    bool IsRightAnswer,
    DifficultyLevel DifficultyLevel,
    QuizType QuizType,
    List<UpdateQuizOptionCommand> Options
) : IRequest<ErrorOr<QuizResult>>;

public record UpdateQuizOptionCommand(
    Guid Id,
    string Title,
    bool IsCorrect,
    bool? MultipleChoiceAnswer
);
