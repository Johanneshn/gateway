using Gateway.Domain.ValueObjects;

namespace Gateway.Domain.Entities;

public class DeviceDataPoint : EntityBase<long>
{
    private DeviceDataPoint()
    {
    } // For EF Core

    private DeviceDataPoint(DeviceId deviceId, double value, DateTimeOffset timestamp)
    {
        DeviceId = deviceId;
        Value = value;
        Timestamp = timestamp;
    }

    public DeviceId DeviceId { get; private set; }
    public double Value { get; private set; }
    public DateTimeOffset Timestamp { get; private set; }

    public static DeviceDataPoint Create(DeviceId deviceId, double value, DateTimeOffset timestamp)
    {
        return new DeviceDataPoint(deviceId, value, timestamp);
    }
}