using Gateway.Application.Common;
using Gateway.Application.Feature.Devices.SaveDataPoint;
using Gateway.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Gateway.Application.Feature.LegacyServer;

public class LegacyServerBackgroundService(ILegacyServer server, IServiceProvider serviceProvider)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await server.StartAsync(stoppingToken);
        await foreach (var dataPoint in server.DataPoints.ReadAllAsync(stoppingToken))
        {
            using var scope = serviceProvider.CreateScope();
            var saveDataPointHandler =
                scope.ServiceProvider.GetRequiredService<ICommandHandler<SaveDataPointCommand, Result>>();
            await saveDataPointHandler.HandleAsync(new SaveDataPointCommand(dataPoint), stoppingToken);
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await server.StopAsync(cancellationToken);
        await base.StopAsync(cancellationToken);
    }
}