using Gateway.Application.Common;
using Gateway.Domain.Interfaces;
using Gateway.Domain.ValueObjects;

namespace Gateway.Application.Feature.Devices.SetConfiguration;

public record SetConfigurationCommand(DeviceId DeviceId, Dictionary<string, string> Configuration);

public class SetConfigurationHandler(IUnitOfWork unitOfWork) : ICommandHandler<SetConfigurationCommand, Result>
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