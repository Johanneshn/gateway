namespace Gateway.Domain.Interfaces;

public interface IReadOnlyRepository<T, in TId> where T : EntityBase<TId> where TId : notnull
{
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
}