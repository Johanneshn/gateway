using Gateway.Domain.Entities;
using Gateway.Domain.Interfaces;

namespace Gateway.Domain.Services;

public class DeviceDataPointService(IUnitOfWork unitOfWork)
{
    public async Task AddDataPointAsync(DeviceDataPoint dataPoint)
    {
        var device = await unitOfWork.Devices.GetByIdAsync(dataPoint.DeviceId);
        if (device == null)
        {
            device = Device.Create(dataPoint.DeviceId);
            await unitOfWork.Devices.AddAsync(device);
        }

        device.UpdateDataPointStats(dataPoint);
        await unitOfWork.DataPoints.AddAsync(dataPoint);
        await unitOfWork.SaveChangesAsync();
    }
}