using Gateway.Domain.Entities;
using Gateway.Domain.Interfaces;
using Gateway.Domain.ValueObjects;

namespace Gateway.Application.Interfaces;

public interface IDeviceRepository : IRepository<Device, DeviceId>
{
}