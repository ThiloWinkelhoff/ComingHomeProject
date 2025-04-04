using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public IEnumerable<string> GerAllDevices()
    {
        return new List<string> { "test1", "test2", "test3" };
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