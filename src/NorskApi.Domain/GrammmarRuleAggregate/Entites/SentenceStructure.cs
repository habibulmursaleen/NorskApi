using NorskApi.Domain.Common.Models;
using NorskApi.Domain.GrammmarRuleAggregate.Events.DomainEvent.ExmapleOfRule;
using NorskApi.Domain.GrammmarRuleAggregate.ValueObjects;

namespace NorskApi.Domain.GrammmarRuleAggregate.Entites;

public sealed class SentenceStructure : Entity<SentenceStructureId>
{
    public string Label { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private SentenceStructure() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    private SentenceStructure(SentenceStructureId id, string label)
        : base(id)
    {
        this.Label = label;
    }

    public static SentenceStructure Create(string label)
    {
        SentenceStructure sentenceStructure = new SentenceStructure(
            SentenceStructureId.CreateUnique(),
            label
        );

        return sentenceStructure;
    }

    public void Update(string label)
    {
        this.Label = label;
    }

    public void Delete() { }
}
