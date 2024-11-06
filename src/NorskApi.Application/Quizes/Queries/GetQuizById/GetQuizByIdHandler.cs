using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Quizes.Models;
using NorskApi.Domain.Common.Errors;
using NorskApi.Domain.QuizAggregate;
using NorskApi.Domain.QuizAggregate.Entites;
using NorskApi.Domain.QuizAggregate.ValueObjects;

namespace NorskApi.Application.Quizes.Queries.GetQuizById;

public record GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, ErrorOr<QuizResult>>
{
    private readonly IQuizRepository quizRepository;

    public GetQuizByIdQueryHandler(IQuizRepository quizRepository)
    {
        this.quizRepository = quizRepository;
    }

    public async Task<ErrorOr<QuizResult>> Handle(
        GetQuizByIdQuery query,
        CancellationToken cancellationToken
    )
    {
        // Use the Create method to create a QuizId from the Guid
        QuizId quizId = QuizId.Create(query.Id);
        Quiz? quiz = await quizRepository.GetById(quizId, cancellationToken);

        if (quiz is null)
        {
            return Errors.QuizesErrors.QuizesNotFound(query.Id);
        }

        List<QuizOptionResult> quizOptions = [];

        foreach (QuizOption option in quiz.QuizOptions)
        {
            quizOptions.Add(
                new QuizOptionResult(
                    option.Id.Value,
                    option.Title,
                    option.IsCorrect,
                    option.MultipleChoiceAnswer,
                    option.CreatedDateTime,
                    option.UpdatedDateTime
                )
            );
        }

        return new QuizResult(
            quiz.Id.Value,
            quiz.EssayId?.Value,
            quiz.TopicId?.Value,
            quiz.Question,
            quiz.Answer,
            quiz.IsRightAnswer,
            quiz.DifficultyLevel,
            quiz.QuizType,
            quizOptions,
            quiz.CreatedDateTime,
            quiz.UpdatedDateTime
        );
    }
}
