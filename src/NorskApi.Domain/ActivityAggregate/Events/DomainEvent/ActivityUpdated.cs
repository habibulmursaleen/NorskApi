using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.ActivityAggregate.Events.DomainEvent
{
    public record ActivityUpdatedDomainEvent(Activity Activity) : IDomainEvent;
}
