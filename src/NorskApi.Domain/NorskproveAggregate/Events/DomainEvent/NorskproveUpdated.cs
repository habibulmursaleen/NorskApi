using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.NorskproveAggregate.Events.DomainEvent
{
    public record NorskproveUpdatedDomainEvent(Norskprove Norskprove) : IDomainEvent;
}
