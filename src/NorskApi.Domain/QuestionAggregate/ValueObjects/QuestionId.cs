using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuestionAggregate.ValueObjects;

public sealed class QuestionId : AggregateRootId<Guid>
{
    private QuestionId()
    {
    }

    private QuestionId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(QuestionId data) => data.Value;

    public static QuestionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static QuestionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
