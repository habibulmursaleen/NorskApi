using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Quizes.Models;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.Entites;

namespace NorskApi.Application.Quizes.Command.CreateQuiz;

public class CreateQuizHandler : IRequestHandler<CreateQuizCommand, ErrorOr<QuizResult>>
{
    private readonly IQuizRepository quizRepository;

    public CreateQuizHandler(IQuizRepository quizRepository)
    {
        this.quizRepository = quizRepository;
    }

    public async Task<ErrorOr<QuizResult>> Handle(
        CreateQuizCommand command,
        CancellationToken cancellationToken
    )
    {
        EssayId? essayId = command.EssayId is not null
            ? EssayId.Create(command.EssayId.Value)
            : null;
        TopicId? topicId = command.TopicId is not null
            ? TopicId.Create(command.TopicId.Value)
            : null;

        DictationId? dictationId = command.DictationId is not null
            ? DictationId.Create(command.DictationId.Value)
            : null;

        Quiz quiz = Quiz.Create(
            essayId,
            topicId,
            dictationId,
            command.Question,
            command.Answer,
            command.IsRightAnswer,
            command.DifficultyLevel,
            command.QuizType,
            command
                .Options.Select(option =>
                    QuizOption.Create(option.Title, option.IsCorrect, option.MultipleChoiceAnswer)
                )
                .ToList()
        );

        await this.quizRepository.Add(quiz, cancellationToken);

        return new QuizResult(
            quiz.Id.Value,
            quiz.EssayId?.Value,
            quiz.TopicId?.Value,
            quiz.DictationId?.Value,
            quiz.Question,
            quiz.Answer,
            quiz.IsRightAnswer,
            quiz.DifficultyLevel,
            quiz.QuizType,
            quiz.QuizOptions.Select(option => new QuizOptionResult(
                    option.Id.Value,
                    option.Title,
                    option.IsCorrect,
                    option.MultipleChoiceAnswer,
                    option.CreatedDateTime,
                    option.UpdatedDateTime
                ))
                .ToList(),
            quiz.CreatedDateTime,
            quiz.UpdatedDateTime
        );
    }
}
