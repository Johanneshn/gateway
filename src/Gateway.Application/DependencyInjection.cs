using Gateway.Application.Features.Devices.SaveDataPoint;
using Gateway.Application.Features.Devices.SetConfiguration;
using Gateway.Application.Features.LegacyServer;
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
        services.AddScoped<SaveDataPointHandler>();
        services.AddScoped<SetConfigurationHandler>();

        // Register background services
        services.AddHostedService<LegacyServerBackgroundService>();


        return services;
    }
}