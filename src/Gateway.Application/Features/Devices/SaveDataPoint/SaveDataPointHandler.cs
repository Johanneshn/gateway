using Gateway.Application.Common;
using Gateway.Domain.Services;

namespace Gateway.Application.Features.Devices.SaveDataPoint;

public class SaveDataPointHandler(DeviceDataPointService deviceDataPointService)
{
    public async Task<Result> HandleAsync(SaveDataPointCommand command, CancellationToken cancellationToken = default)
    {
        await deviceDataPointService.AddDataPointAsync(command.DeviceDataPoint);
        return Result.Success();
    }
}