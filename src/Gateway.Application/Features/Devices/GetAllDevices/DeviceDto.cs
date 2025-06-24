using Gateway.Domain.Entities;

namespace Gateway.Application.Features.Devices.GetAllDevices;

public record DeviceDto
{
    public DateTimeOffset LastModified { get; init; }

    public DateTimeOffset Created { get; init; }

    public Guid Id { get; init; }

    public static DeviceDto FromEntity(Device device)
    {
        return new DeviceDto
        {
            Id = device.Id.Value,
            Created = device.Created,
            LastModified = device.LastModified
        };
    }
}