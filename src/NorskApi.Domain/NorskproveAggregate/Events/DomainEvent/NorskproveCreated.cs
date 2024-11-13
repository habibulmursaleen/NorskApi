using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.NorskproveAggregate.Events.DomainEvent
{
    public record NorskproveCreatedDomainEvent(Norskprove Norskprove) : IDomainEvent;
}
