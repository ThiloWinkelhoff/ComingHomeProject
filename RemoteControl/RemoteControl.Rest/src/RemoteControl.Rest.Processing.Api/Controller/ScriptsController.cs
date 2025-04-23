using MediatR;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Processing.Api.Controller;

[ApiController]
[Route("[controller]")]
public class ScriptsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ScriptsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllScriptsAsync()
    {
        IEnumerable<ScriptDto> devices = await _mediator.Send(new GetScriptsCommand());
        return Ok(devices);
    }
}