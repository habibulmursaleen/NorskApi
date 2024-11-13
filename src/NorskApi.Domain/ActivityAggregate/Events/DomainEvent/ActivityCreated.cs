using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.ActivityAggregate.Events.DomainEvent
{
    public record ActivityCreatedDomainEvent(Activity Activity) : IDomainEvent;
}
