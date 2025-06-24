namespace Gateway.Domain;

public abstract class EntityBase<TKey> where TKey : notnull
{
    public TKey Id { get; protected set; }
    public DateTimeOffset Created { get; private set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset LastModified { get; private set; } = DateTimeOffset.UtcNow;

    public void UpdateLastModified()
    {
        LastModified = DateTimeOffset.UtcNow;
    }
}