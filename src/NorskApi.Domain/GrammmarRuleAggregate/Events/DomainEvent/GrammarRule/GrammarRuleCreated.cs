using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.GrammarRule
{
    public record GrammarRuleCreatedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.GrammarRule GrammarRule) : IDomainEvent;
}

