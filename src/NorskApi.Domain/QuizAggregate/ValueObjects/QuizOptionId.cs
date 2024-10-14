using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.ValueObjects;
public sealed class QuizOptionId : AggregateRootId<Guid>
{
    private QuizOptionId()
    {
    }

    private QuizOptionId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(QuizOptionId data) => data.Value;

    public static QuizOptionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static QuizOptionId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
