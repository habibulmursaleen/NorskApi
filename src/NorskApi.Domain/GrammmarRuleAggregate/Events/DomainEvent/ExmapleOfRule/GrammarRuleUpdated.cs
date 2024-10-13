using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.ExmapleOfRule
{
    public record ExmapleOfRuleUpdatedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.Entites.ExampleOfRule ExmapleOfRule) : IDomainEvent;
}

