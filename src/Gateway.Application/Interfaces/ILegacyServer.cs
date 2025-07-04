using System.Threading.Channels;
using Gateway.Domain.Entities;

namespace Gateway.Application.Interfaces;

public interface ILegacyServer
{
    ChannelReader<DeviceDataPoint> DataPoints { get; }
    Task StartAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);
}