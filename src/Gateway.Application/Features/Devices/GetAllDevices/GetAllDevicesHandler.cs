using Gateway.Domain.Entities;
using Gateway.Domain.Interfaces;
using Gateway.Domain.ValueObjects;

namespace Gateway.Application.Features.Devices.GetAllDevices;

public class GetAllDevicesHandler(IReadOnlyRepository<Device, DeviceId> repository)
{
    public async Task<IReadOnlyList<DeviceDto>> HandleAsync(GetAllDevicesQuery _,
        CancellationToken cancellationToken = default)
    {
        var devices = await repository.GetAllAsync(cancellationToken);
        return devices.Select(DeviceDto.FromEntity).ToList();
    }
}