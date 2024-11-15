using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.WordAggregate.ValueObjects;

public sealed class WordGrammarId : ValueObject
{
    private WordGrammarId() { }

    public Guid Value { get; set; }

    public WordGrammarId(Guid value)
    {
        this.Value = value;
    }

    public static WordGrammarId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static WordGrammarId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
