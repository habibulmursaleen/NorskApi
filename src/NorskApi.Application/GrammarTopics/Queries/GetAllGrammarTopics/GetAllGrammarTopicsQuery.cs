using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarTopics.Models;

namespace NorskApi.Application.GrammarTopics.Queries.GetAllGrammarTopics;

public record GetAllGrammarTopicsQuery(QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<GrammarTopicResult>>>;
