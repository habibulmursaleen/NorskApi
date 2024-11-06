using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TaskWorkAggregate.Events.DomainEvent
{
    public record TaskWorkUpdatedDomainEvent(TaskWork TaskWork) : IDomainEvent;
}
