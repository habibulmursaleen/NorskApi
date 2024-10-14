using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.SubjunctionAgreegate.Events.DomainEvent
{
    public record SubjunctionUpdatedDomainEvent(Subjunction Subjunction) : IDomainEvent;
}

