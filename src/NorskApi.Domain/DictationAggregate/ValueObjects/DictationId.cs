using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.DictationAggregate.ValueObjects;
public sealed class DictationId : AggregateRootId<Guid>
{
    private DictationId()
    {
    }

    private DictationId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(DictationId data) => data.Value;

    public static DictationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static DictationId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
