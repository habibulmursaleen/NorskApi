using ErrorOr;
using MediatR;
using NorskApi.Application.Common.Interfaces.Persistance;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Quizes.Models;
using NorskApi.Domain.QuizAggregate;

namespace NorskApi.Application.Quizes.Queries.GetAllQuizes;

public class GetAllQuizesQueryHandler
    : IRequestHandler<GetAllQuizesQuery, ErrorOr<List<QuizResult>>>
{
    private readonly IQuizRepository quizRepository;

    public GetAllQuizesQueryHandler(IQuizRepository quizRepository)
    {
        this.quizRepository = quizRepository;
    }

    public async Task<ErrorOr<List<QuizResult>>> Handle(
        GetAllQuizesQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Quiz> quizes = new List<Quiz>();
        QuizQueryParamsFilters? filters = query.Filters;
        var quiz = await this.quizRepository.GetAll(filters, cancellationToken);

        var quizResult = quiz.Select(quiz => new QuizResult(
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
            ))
            .ToList();

        return quizResult;
    }
}
