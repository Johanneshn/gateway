using Gateway.Domain.ValueObjects;

namespace Gateway.Domain.Entities;

public class Device : EntityBase<DeviceId>
{
    private readonly Dictionary<string, string> _configuration = new();

    private Device(DeviceId id)
    {
        Id = id;
    }

    private Device()
    {
    }

    public IReadOnlyDictionary<string, string> Config => _configuration;

    public DateTimeOffset? LatestDataPointTime { get; private set; }
    public long DataPointCount { get; private set; }

    public void UpdateDataPointStats(DeviceDataPoint dataPoint)
    {
        DataPointCount++;
        LatestDataPointTime = dataPoint.Timestamp;
    }

    public void SetConfig(IDictionary<string, string> config)
    {
        _configuration.Clear();
        foreach (var kvp in config) _configuration[kvp.Key] = kvp.Value;
    }

    public static Device Create(DeviceId id)
    {
        return new Device(id);
    }
}