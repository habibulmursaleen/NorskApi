using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.Events.DomainEvent.Paragraph
{
    public record ParagraphDeletedDomainEvent(NorskApi.Domain.EssayAggregate.Entities.Paragraph Paragraph) : IDomainEvent;
}

