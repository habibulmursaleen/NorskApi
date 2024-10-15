using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.Events.DomainEvent.QuizOption
{
    public record QuizOptionDeletedDomainEvent(NorskApi.Domain.QuizAggregate.Entites.QuizOption QuizOption) : IDomainEvent;
}

