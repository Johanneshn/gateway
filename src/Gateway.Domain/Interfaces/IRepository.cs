namespace Gateway.Domain.Interfaces;

public interface IRepository<T, in TId> : IReadOnlyRepository<T, TId>
    where T : EntityBase<TId>
    where TId : notnull
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TId id, CancellationToken cancellationToken = default);
}