using System.Threading.Channels;
using Gateway.Application.Interfaces;
using Gateway.Domain.Entities;
using Gateway.Domain.ValueObjects;

namespace Gateway.Infrastructure.LegacyServer;

public class LegacyServer : ILegacyServer
{
    // Simulate a list of device IDs for demonstration purposes
    private readonly List<DeviceId> _deviceIds =
    [
        new(Guid.NewGuid()),
        new(Guid.NewGuid()),
        new(Guid.NewGuid())
    ];

    private CancellationTokenSource? _cts;

    private Channel<DeviceDataPoint> Channel { get; } =
        System.Threading.Channels.Channel.CreateUnbounded<DeviceDataPoint>();

    public ChannelReader<DeviceDataPoint> DataPoints => Channel.Reader;

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var channelWriter = Channel.Writer;

        // Offload the loop to a background task
        _ = Task.Run(async () =>
        {
            while (!_cts.IsCancellationRequested)
            {
                await Task.Delay(1000, _cts.Token);

                var dataPoint = DeviceDataPoint.Create(
                    _deviceIds[new Random().Next(_deviceIds.Count)],
                    new Random().NextDouble(),
                    DateTime.UtcNow
                );

                await channelWriter.WriteAsync(dataPoint, _cts.Token);
            }

            channelWriter.Complete();
        }, _cts.Token);

        await Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        _cts?.Cancel();
        return Task.CompletedTask;
    }
}