using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.WordAggregate.ValueObjects;

public sealed class WordGrammarId : ValueObject
{
#pragma warning disable CS0628 // New protected member declared in sealed type
    public Guid Value { get; protected set; }
#pragma warning restore CS0628 // New protected member declared in sealed type
    private WordGrammarId() { }

    private WordGrammarId(Guid value)
    {
        this.Value = value;
    }

    public static implicit operator Guid(WordGrammarId data) => data.Value;

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
