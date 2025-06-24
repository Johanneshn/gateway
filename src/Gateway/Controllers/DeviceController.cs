using Gateway.Application.Features.Devices.GetAllDevices;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DevicesController(GetAllDevicesHandler getAllDevicesHandler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeviceDto>>> GetAll(CancellationToken cancellationToken)
    {
        var devices = await getAllDevicesHandler.HandleAsync(new GetAllDevicesQuery(), cancellationToken);
        return Ok(devices);
    }
}