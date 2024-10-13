using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.ExmapleOfRule
{
    public record ExmapleOfRuleDeletedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.Entites.ExampleOfRule ExmapleOfRule) : IDomainEvent;
}

