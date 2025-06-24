using Gateway.Domain.ValueObjects;

namespace Gateway.Application.Features.Devices.SetConfiguration;

public record SetConfigurationCommand(DeviceId DeviceId, Dictionary<string, string> Configuration);