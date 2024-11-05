using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.Questions.Models;

namespace NorskApi.Application.Questions.Queries.GetAllQuestions;

public record GetAllQuestionsQuery(Guid? EssayId, QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<QuestionResult>>>;
