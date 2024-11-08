namespace NorskApi.Application.GrammarRules.Command.DeleteGrammarRule;

using ErrorOr;
using MediatR;

public record DeleteGrammarRuleCommand(Guid TopicId, Guid Id)
    : IRequest<ErrorOr<DeleteGrammarRuleResult>>;
