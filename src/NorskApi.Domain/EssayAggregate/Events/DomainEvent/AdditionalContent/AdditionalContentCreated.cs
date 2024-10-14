using NorskApi.Domain.Common.Models;
using NorskApi.Domain.EssayAggregate.Entities;

namespace NorskApi.Domain.EssayAggregate.Events.DomainEvent.AdditionalContent
{
    public record AdditionalContentCreatedDomainEvent(NorskApi.Domain.EssayAggregate.Entities.AdditionalContent AdditionalContent) : IDomainEvent;
}

