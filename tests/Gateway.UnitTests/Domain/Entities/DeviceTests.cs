using Gateway.Domain.Entities;
using Gateway.Domain.ValueObjects;

namespace Gateway.UnitTests.Domain.Entities;

public class DeviceTests
{
    [Fact]
    public void CreateDevice_WhenCalled_CreatesDeviceWithCorrectProperties()
    {
        // Arrange & Act
        var deviceId = new DeviceId(Guid.NewGuid());
        var device = Device.Create(deviceId);

        // Assert
        Assert.Equal(deviceId, device.Id);
        Assert.Empty(device.Config);
        Assert.Null(device.LatestDataPointTime);
        Assert.Equal(0, device.DataPointCount);
    }
}