using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.EssayAggregate.ValueObjects;
public sealed class AdditionalContentId : AggregateRootId<Guid>
{
    private AdditionalContentId()
    {
    }

    private AdditionalContentId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(AdditionalContentId data) => data.Value;

    public static AdditionalContentId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AdditionalContentId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
