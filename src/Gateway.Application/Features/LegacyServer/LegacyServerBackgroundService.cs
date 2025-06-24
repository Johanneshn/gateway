using Gateway.Application.Features.Devices.SaveDataPoint;
using Gateway.Application.Interfaces;
using Gateway.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gateway.Application.Features.LegacyServer;

public class LegacyServerBackgroundService(
    ILegacyServer server,
    IServiceProvider serviceProvider
) : BackgroundService
{
    private const int BatchSize = 10;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await server.StartAsync(stoppingToken);

        var batch = new List<DeviceDataPoint>(BatchSize);

        await foreach (var dataPoint in server.DataPoints.ReadAllAsync(stoppingToken))
        {
            batch.Add(dataPoint);

            if (batch.Count >= BatchSize)
            {
                await ProcessBatchAsync(batch, stoppingToken);
                batch.Clear();
            }
        }

        if (batch.Count > 0)
        {
            await ProcessBatchAsync(batch, stoppingToken);
        }
    }

    // Only done to avoid creating a new scope for each data point
    private async Task ProcessBatchAsync(List<DeviceDataPoint> batch, CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<SaveDataPointHandler>();

        foreach (var dataPoint in batch)
        {
            await handler.HandleAsync(new SaveDataPointCommand(dataPoint), stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await server.StopAsync(cancellationToken);
        await base.StopAsync(cancellationToken);
    }
}