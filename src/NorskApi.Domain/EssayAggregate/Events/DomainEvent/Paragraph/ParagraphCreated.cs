using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.Events.DomainEvent.Paragraph
{
    public record ParagraphCreatedDomainEvent(NorskApi.Domain.EssayAggregate.Entities.Paragraph Paragraph) : IDomainEvent;
}

