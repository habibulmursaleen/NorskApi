using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.Exception
{
    public record ExceptionUpdatedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.Entites.Exception Exception) : IDomainEvent;
}

