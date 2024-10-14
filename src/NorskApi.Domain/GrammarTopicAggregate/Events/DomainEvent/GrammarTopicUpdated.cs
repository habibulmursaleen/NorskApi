using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.GrammarTopicAggregate.Events.DomainEvent
{
    public record GrammarTopicUpdatedDomainEvent(GrammarTopic GrammarTopic) : IDomainEvent;
}

