namespace NorskApi.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>, IHasTimeStamp, IHasDomainEvents
    where TId : notnull
{
    private readonly List<IDomainEvent> domainEvents = new();

#pragma warning disable CS8618
    protected Entity()
    {
    }
#pragma warning restore CS8618

    protected Entity(TId id)
    {
        this.Id = id;
    }

    public TId Id { get; protected set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => this.domainEvents.AsReadOnly();

    public DateTime CreatedDateTime { get; set; }

    public DateTime UpdatedDateTime { get; set; }

    public static bool operator ==(Entity<TId> left, Entity<TId> right) => Equals(left, right);

    public static bool operator !=(Entity<TId> left, Entity<TId> right) => !Equals(left, right);

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && this.Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return this.Equals((object?)other);
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        this.domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        this.domainEvents.Clear();
    }
}