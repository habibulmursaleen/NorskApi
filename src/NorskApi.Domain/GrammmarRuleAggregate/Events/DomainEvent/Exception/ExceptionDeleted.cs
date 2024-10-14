using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.Exception
{
    public record ExceptionDeletedDomainEvent(NorskApi.Domain.GrammmarRuleAggregate.Entites.Exception Exception) : IDomainEvent;
}

