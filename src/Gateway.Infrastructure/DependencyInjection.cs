using Gateway.Application.Interfaces;
using Gateway.Domain.Interfaces;
using Gateway.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=gw.db"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSingleton<ILegacyServer, LegacyServer.LegacyServer>();

        return services;
    }
}