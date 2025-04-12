using MediatR;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Processing.Api.Controller;

[ApiController]
[Route("api/[controller]")]
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
        IEnumerable<DeviceDto> devices = await _mediator.Send(new GetConnectedDevicesCommand());
        return Ok(devices);
    }


    [HttpGet("connected")]
    public IEnumerable<string> GetConnectedDevices()
    {
        return new List<string> { "test1", "test2", "test3" };
    }

    [HttpGet("disconnected")]
    public IEnumerable<string> GetDisconnectedDevices()
    {
        return new List<string> { "test1", "test2", "test3" };
    }

    [HttpGet("{deviceID}/get-connected-scripts")]
    public IEnumerable<string> GetConnectedScripts()
    {
        return new List<string> { "test1", "test2", "test3" };
    }

    [HttpGet("{deviceID}/get-unconnected-scripts")]
    public IEnumerable<string> GetUnconnectedScripts()
    {
        return new List<string> { "test1", "test2", "test3" };
    }
}