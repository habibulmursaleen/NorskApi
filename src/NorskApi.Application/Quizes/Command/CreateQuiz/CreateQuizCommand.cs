using ErrorOr;
using MediatR;
using NorskApi.Application.Quizes.Models;
using NorskApi.Domain.Common.Enums;
using NorskApi.Domain.QuizAggregate.Entites;
using NorskApi.Domain.QuizAggregate.Enums;

namespace NorskApi.Application.Quizes.Command.CreateQuiz;

public record CreateQuizCommand(
    Guid? EssayId,
    Guid? TopicId,
    string Question,
    string? Answer,
    bool IsRightAnswer,
    DifficultyLevel DifficultyLevel,
    QuizType QuizType,
    List<CreateQuizOptionCommand> Options
) : IRequest<ErrorOr<QuizResult>>;

public record CreateQuizOptionCommand(string Title, bool IsCorrect, bool? MultipleChoiceAnswer);
