using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TaskAggregate.Events.DomainEvent
{
    public record TaskCreatedDomainEvent(Task Task) : IDomainEvent;
}

