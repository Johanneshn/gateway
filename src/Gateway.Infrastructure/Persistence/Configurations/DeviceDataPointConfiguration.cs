using Gateway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gateway.Infrastructure.Persistence.Configurations;

public class DeviceDataPointConfiguration : IEntityTypeConfiguration<DeviceDataPoint>
{
    public void Configure(EntityTypeBuilder<DeviceDataPoint> entity)
    {
        entity.HasKey(dp => dp.Id);

        entity.Property(dp => dp.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        entity.Property(dp => dp.DeviceId)
            .HasConversion(ValueConverters.DeviceId)
            .IsRequired();

        entity.HasOne<Device>()
            .WithMany()
            .HasForeignKey(dp => dp.DeviceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}