using System.Text.Json.Serialization;
using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.NorskproveAggregate.ValueObjects;

public sealed class NorskproveId : AggregateRootId<Guid>
{
    private NorskproveId() { }

    public NorskproveId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(NorskproveId data) => data.Value;

    public static NorskproveId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static NorskproveId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
