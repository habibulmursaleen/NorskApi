namespace NorskApi.Domain.Common.Models;

public abstract class AggregateRoot<TId, TIdType> : Entity<TId>
    where TId : AggregateRootId<TIdType>
{
    protected AggregateRoot(TId id)
        : base(id)
    {
        this.Id = id;
    }

    protected AggregateRoot()
    {
    }

    public new AggregateRootId<TIdType> Id { get; protected set; } = null!;
}
