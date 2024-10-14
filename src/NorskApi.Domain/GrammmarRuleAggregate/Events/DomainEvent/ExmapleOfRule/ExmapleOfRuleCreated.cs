using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.ExmapleOfRule
{
    public record ExmapleOfRuleCreatedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.Entites.ExampleOfRule ExmapleOfRule) : IDomainEvent;
}

