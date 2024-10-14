using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.SubjunctionAgreegate.Events.DomainEvent
{
    public record SubjunctionCreatedDomainEvent(Subjunction Subjunction) : IDomainEvent;
}

