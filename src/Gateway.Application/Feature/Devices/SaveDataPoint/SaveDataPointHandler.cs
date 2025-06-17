using Gateway.Application.Common;
using Gateway.Domain.Entities;
using Gateway.Domain.Services;

namespace Gateway.Application.Feature.Devices.SaveDataPoint;

public record SaveDataPointCommand(DeviceDataPoint DeviceDataPoint);

public class SaveDataPointHandler(DeviceDataPointService deviceDataPointService)
    : ICommandHandler<SaveDataPointCommand, Result>
{
    public async Task<Result> HandleAsync(SaveDataPointCommand command, CancellationToken cancellationToken = default)
    {
        await deviceDataPointService.AddDataPointAsync(command.DeviceDataPoint);
        return Result.Success();
    }
}