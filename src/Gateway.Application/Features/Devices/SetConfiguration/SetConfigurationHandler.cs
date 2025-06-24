using Gateway.Application.Common;
using Gateway.Domain.Interfaces;

namespace Gateway.Application.Features.Devices.SetConfiguration;

public class SetConfigurationHandler(IUnitOfWork unitOfWork)
{
    public async Task<Result> HandleAsync(SetConfigurationCommand command,
        CancellationToken cancellationToken = default)
    {
        var device = await unitOfWork.Devices.GetByIdAsync(command.DeviceId, cancellationToken);
        if (device == null) return Result.Failure("Device Id not found");

        device.SetConfig(command.Configuration);
        await unitOfWork.Devices.UpdateAsync(device, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}