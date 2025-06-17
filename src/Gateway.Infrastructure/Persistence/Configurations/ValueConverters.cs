// filepath: Gateway.Infrastructure/Persistence/Configurations/ValueConverters.cs

using System.Text.Json;
using Gateway.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public static class ValueConverters
{
    public static readonly ValueConverter<DeviceId, Guid> DeviceId =
        new(v => v.Value, v => new DeviceId(v));

    public static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.General);

    public static readonly ValueComparer<Dictionary<string, string>> ConfigDictionaryComparer =
        new(
            (d1, d2) => d1!.SequenceEqual(d2!),
            d => d.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            d => d.ToDictionary(entry => entry.Key, entry => entry.Value)
        );
}