using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.Events.DomainEvent.AdditionalContent
{
    public record AdditionalContentDeletedDomainEvent(NorskApi.Domain.EssayAggregate.Entities.AdditionalContent AdditionalContent) : IDomainEvent;
}

