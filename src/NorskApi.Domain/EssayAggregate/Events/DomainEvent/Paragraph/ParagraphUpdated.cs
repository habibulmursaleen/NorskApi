using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.Events.DomainEvent.Paragraph
{
    public record ParagraphUpdatedDomainEvent(NorskApi.Domain.EssayAggregate.Entities.Paragraph Paragraph) : IDomainEvent;
}
