using Gateway.Domain.Entities;
using Gateway.Domain.ValueObjects;

namespace Gateway.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<DeviceDataPoint, long> DataPoints { get; }
    IRepository<Device, DeviceId> Devices { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}