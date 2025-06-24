using Gateway.Domain.Entities;

namespace Gateway.Application.Features.Devices.SaveDataPoint;

public record SaveDataPointCommand(DeviceDataPoint DeviceDataPoint);