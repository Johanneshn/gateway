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
        new(Guid.Parse("6e09e465-d2a1-45c7-b7f0-515fcfb914ad")),
        new(Guid.Parse("3bb36463-57e7-4e7b-b3b9-545149a12912")),
        new(Guid.Parse("66f384c5-7ffd-47f1-8b17-543f498114b4"))
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