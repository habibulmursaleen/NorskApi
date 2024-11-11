using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Quizes.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.DictationAggregate;
using NorskApi.Domain.DictationAggregate.ValueObjects;
using NorskApi.Domain.EssayAggregate.ValueObjects;
using NorskApi.Domain.GrammarTopicAggregate.ValueObjects;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.Entites;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Application.Quizes.Command.UpdateQuiz;

public class UpdateQuizHandler : IRequestHandler<UpdateQuizCommand, ErrorOr<QuizResult>>
{
    private readonly IQuizRepository quizRepository;

    public UpdateQuizHandler(IQuizRepository quizRepository)
    {
        this.quizRepository = quizRepository;
    }

    public async Task<ErrorOr<QuizResult>> Handle(
        UpdateQuizCommand command,
        CancellationToken cancellationToken
    )
    {
        QuizId quizId = QuizId.Create(command.Id);
        EssayId? essayId = command.EssayId is not null
            ? EssayId.Create(command.EssayId.Value)
            : null;
        TopicId? topicId = command.TopicId is not null
            ? TopicId.Create(command.TopicId.Value)
            : null;

        DictationId? dictationId = command.DictationId is not null
            ? DictationId.Create(command.DictationId.Value)
            : null;

        Quiz? quiz = await quizRepository.GetById(quizId, cancellationToken);

        if (quiz is null)
        {
            return Errors.QuizesErrors.QuizesNotFound(command.Id);
        }

        List<QuizOption> optionsToUpdate = new List<QuizOption>();

        foreach (UpdateQuizOptionCommand updateOption in command.Options)
        {
            QuizOptionId optionId = QuizOptionId.Create(updateOption.Id);
            QuizOption? option = quiz.QuizOptions.FirstOrDefault(option => option.Id == optionId);

            if (option is null)
            {
                optionsToUpdate.Add(
                    QuizOption.Create(
                        updateOption.Title,
                        updateOption.IsCorrect,
                        updateOption.MultipleChoiceAnswer
                    )
                );
            }
            else
            {
                option.Update(
                    updateOption.Title,
                    updateOption.IsCorrect,
                    updateOption.MultipleChoiceAnswer
                );
                optionsToUpdate.Add(option);
            }
        }

        var optionsToRemove = quiz
            .QuizOptions.Where(option =>
                !command.Options.Any(updateOption => updateOption.Id == option.Id.Value)
            )
            .ToList();

        optionsToUpdate = optionsToUpdate
            .Where(option => !optionsToRemove.Contains(option))
            .ToList();

        quiz.Update(
            essayId,
            topicId,
            dictationId,
            command.Question,
            command.Answer,
            command.IsRightAnswer,
            command.DifficultyLevel,
            command.QuizType,
            optionsToUpdate
        );

        await this.quizRepository.Update(quiz, cancellationToken);

        List<QuizOptionResult> optionsResult = optionsToUpdate
            .Select(option => new QuizOptionResult(
                option.Id.Value,
                option.Title,
                option.IsCorrect,
                option.MultipleChoiceAnswer,
                option.CreatedDateTime,
                option.UpdatedDateTime
            ))
            .ToList();

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
            optionsResult,
            quiz.CreatedDateTime,
            quiz.UpdatedDateTime
        );
    }
}
