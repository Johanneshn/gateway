using Gateway.Domain.Entities;
using Gateway.Domain.Interfaces;
using Gateway.Domain.ValueObjects;

namespace Gateway.Infrastructure.Persistence;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public void Dispose()
    {
        context?.Dispose();
    }

    public IRepository<DeviceDataPoint, long> DataPoints { get; } = new Repository<DeviceDataPoint, long>(context);
    public IRepository<Device, DeviceId> Devices { get; } = new Repository<Device, DeviceId>(context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}