using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TaskAggregate.Events.DomainEvent
{
    public record TaskUpdatedDomainEvent(Task Task) : IDomainEvent;
}

