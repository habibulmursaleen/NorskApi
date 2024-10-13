using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.ValueObjects;
public sealed class QuizId : AggregateRootId<Guid>
{
    private QuizId()
    {
    }

    private QuizId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(QuizId data) => data.Value;

    public static QuizId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static QuizId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
