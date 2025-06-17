using Gateway.Domain.ValueObjects;

namespace Gateway.Application.Interfaces;

public interface ICloudService : ICloudFileService
{
    Task<bool> GetConfigurationAsync(DeviceId deviceId, CancellationToken cancellationToken);

    Task<bool> SetConfigurationAsync(DeviceId deviceId, Dictionary<string, string> config,
        CancellationToken cancellationToken);
}

public interface ICloudFileService
{
    Task<bool> UploadFileAsync(DeviceId deviceId, byte[] fileBytes, CancellationToken cancellationToken);
}