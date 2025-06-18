using System.Text.Json;
using Gateway.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gateway.Infrastructure.Persistence.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> entity)
    {
        entity.HasKey(d => d.Id);
        entity.Property(d => d.Id)
            .HasConversion(ValueConverters.DeviceId)
            .IsRequired();

        entity.Property<Dictionary<string, string>>("_configuration")
            .HasColumnName("Configuration")
            .HasConversion(
                v => JsonSerializer.Serialize(v, ValueConverters.JsonOptions),
                s => JsonSerializer.Deserialize<Dictionary<string, string>>(s, ValueConverters.JsonOptions)!
            )
            .Metadata.SetValueComparer(ValueComparer.CreateDefault<Dictionary<string, string>>(true));

        entity.Ignore(nameof(Device.Config));
    }
}