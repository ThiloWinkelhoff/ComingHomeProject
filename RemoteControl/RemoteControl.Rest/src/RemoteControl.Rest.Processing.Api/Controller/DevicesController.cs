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

    [HttpGet("skripts")]
    public IEnumerable<string> GetSkripts()
    {
        return new List<string> { "test1", "test2", "test3" };
    }

    [HttpGet("mappings")] // Unique route
    public IEnumerable<string> GetMappigs()
    {
        return new List<string> { "test1", "test2", "test3" };
    }
}
