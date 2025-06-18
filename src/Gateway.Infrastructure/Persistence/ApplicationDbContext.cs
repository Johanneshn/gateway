using Gateway.Domain.Entities;
using Gateway.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Gateway.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceDataPoint> DeviceDataPoints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        modelBuilder.ApplyConfiguration(new DeviceDataPointConfiguration());
    }
}