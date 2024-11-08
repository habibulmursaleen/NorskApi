using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarRules.Models;

namespace NorskApi.Application.GrammarRules.Queries.GetAllGrammarRules;

public record GetAllGrammarRulesQuery(Guid? TopicId, QueryParamsWithTopicFilters Filters)
    : IRequest<ErrorOr<List<GrammarRuleResult>>>;
