using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammarTopicAggregate.Events.DomainEvent
{
    public record GrammarTopicDeletedDomainEvent(GrammarTopic GrammarTopic) : IDomainEvent;
}

