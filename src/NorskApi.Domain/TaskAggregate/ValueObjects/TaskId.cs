using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TaskAggregate.ValueObjects;
public sealed class TaskId : AggregateRootId<Guid>
{
    private TaskId()
    {
    }

    private TaskId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(TaskId data) => data.Value;

    public static TaskId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static TaskId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
