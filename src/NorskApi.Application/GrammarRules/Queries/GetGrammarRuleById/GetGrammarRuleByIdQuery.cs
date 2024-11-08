using ErrorOr;
using MediatR;
using NorskApi.Application.GrammarRules.Models;

namespace NorskApi.Application.GrammarRules.Queries.GetGrammarRuleById;

public record GetGrammarRuleByIdQuery(Guid TopicId, Guid Id) : IRequest<ErrorOr<GrammarRuleResult>>;
