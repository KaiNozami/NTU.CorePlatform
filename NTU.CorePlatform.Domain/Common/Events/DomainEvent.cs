namespace NTU.CorePlatform.Domain.Common.Events;

public abstract class DomainEvent
{
    public DateTime OccurredOn { get; protected set; } = DateTime.UtcNow;
}

public class EntitySoftDeletedEvent<TId> : DomainEvent
{
    public TId EntityId { get; }

    public EntitySoftDeletedEvent(TId entityId)
    {
        EntityId = entityId;
    }
}

public class EntityRestoredEvent<TId> : DomainEvent
{
    public TId EntityId { get; }

    public EntityRestoredEvent(TId entityId)
    {
        EntityId = entityId;
    }
}
