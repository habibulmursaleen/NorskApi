using ErrorOr;
using MediatR;
using NorskApi.Application.Common.QueryParamsBuilder;
using NorskApi.Application.GrammarRules.Models;

namespace NorskApi.Application.GrammarRules.Queries.GetAllGrammarRules;

public record GetAllGrammarRulesQuery(Guid? TopicId, QueryParamsBaseFilters Filters)
    : IRequest<ErrorOr<List<GrammarRuleResult>>>;
