using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.GrammarRule
{
    public record GrammarRuleDeletedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.GrammarRule GrammarRule) : IDomainEvent;
}

