using Gateway.Application.Common;
using Gateway.Application.Feature.Devices.SaveDataPoint;
using Gateway.Application.Feature.Devices.SetConfiguration;
using Gateway.Application.Feature.LegacyServer;
using Gateway.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        // Register domain services
        services.AddScoped<DeviceDataPointService>();
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services
        // TODO: register with reflection
        services.AddScoped<ICommandHandler<SaveDataPointCommand, Result>, SaveDataPointHandler>();
        services.AddScoped<ICommandHandler<SetConfigurationCommand, Result>, SetConfigurationHandler>();

        // Register background services
        services.AddHostedService<LegacyServerBackgroundService>();


        return services;
    }
}