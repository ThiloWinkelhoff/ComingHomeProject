using MediatR;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Processing.Api.Controller;

[ApiController]
[Route("[controller]")]
public class DevicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public DevicesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeviceDto>>> GetAllDevices()
    {
        IEnumerable<DeviceDto> devices = await _mediator.Send(new GetDevicesCommand());
        return Ok(devices);
    }
}