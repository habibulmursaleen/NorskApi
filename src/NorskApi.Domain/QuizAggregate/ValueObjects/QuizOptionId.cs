using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.QuizAggregate.ValueObjects;

public sealed class QuizOptionId : ValueObject
{
    private QuizOptionId() { }

    public Guid Value { get; set; }

    public QuizOptionId(Guid value)
    {
        this.Value = value;
    }

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
