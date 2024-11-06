using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Quizes.Models;

namespace NorskApi.Application.Quizes.Queries.GetAllQuizes;

public record GetAllQuizesQuery(QuizQueryParamsFilters Filters)
    : IRequest<ErrorOr<List<QuizResult>>>;
