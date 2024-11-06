using NorskApi.Domain.Common.Models;

namespace NorskApi.Domain.TaskWorkAggregate.ValueObjects;

public sealed class TaskWorkId : AggregateRootId<Guid>
{
    private TaskWorkId() { }

    private TaskWorkId(Guid value)
    {
        this.Value = value;
    }

    public override Guid Value { get; protected set; }

    public static implicit operator Guid(TaskWorkId data) => data.Value;

    public static TaskWorkId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static TaskWorkId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return this.Value;
    }
}
