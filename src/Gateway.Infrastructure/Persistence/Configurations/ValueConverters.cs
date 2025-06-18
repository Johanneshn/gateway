// filepath: Gateway.Infrastructure/Persistence/Configurations/ValueConverters.cs

using System.Text.Json;
using Gateway.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gateway.Infrastructure.Persistence.Configurations;

public static class ValueConverters
{
    public static readonly ValueConverter<DeviceId, Guid> DeviceId =
        new(v => v.Value, v => new DeviceId(v));

    public static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.General);
}