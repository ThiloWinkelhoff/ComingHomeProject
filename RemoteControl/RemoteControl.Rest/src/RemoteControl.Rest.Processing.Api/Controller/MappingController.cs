using MediatR;
using Microsoft.AspNetCore.Mvc;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Processing.Api.Controller;

[ApiController]
[Route("mapping")]
public class MappingController : ControllerBase
{
    private readonly IMediator _mediator;

    public MappingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Adds a mapping between a script and a device.
    /// </summary>
    /// <param name="scriptId">The ID of the script.</param>
    /// <param name="deviceId">The ID of the device.</param>
    /// <returns>Returns true if the mapping was added, otherwise 404.</returns>
    [HttpPost("add")]
    public async Task<ActionResult<bool>> AddMapping([FromBody] AddMappingRequest request)
    {
        bool result = await _mediator.Send(new AddMappingCommand(request.ScriptId,
            request.DeviceId));

        if (!result)
        {
            return NotFound("Device or Script not found.");
        }

        return Ok(true);
    }

    /// <summary>
    ///     Removes a mapping between a script and a device.
    /// </summary>
    /// <param name="scriptId">The ID of the script.</param>
    /// <param name="deviceId">The ID of the device.</param>
    /// <returns>Returns true if the mapping was deleted, otherwise 404.</returns>
    [HttpDelete("remove")]
    public async Task<ActionResult<bool>> RemoveMapping([FromBody] RemoveMappingRequest request)
    {
        bool result = await _mediator.Send(new RemoveMappingCommand(request.ScriptId,
            request.DeviceId));

        if (!result)
        {
            return NotFound("Mapping not found.");
        }

        return Ok(true);
    }

    /// <summary>
    ///     Fetches Scripts which are not mapped to the <c>Device</c> with the
    ///     identifier <paramref name="id" />
    ///     connection
    /// </summary>
    /// <param name="id">The <c>id</c> of the <c>Device</c></param>
    /// <returns></returns>
    [HttpGet("Script/{id}/Unmapped")]
    public async Task<IActionResult> GetUnmappedDevices(int id)
    {
        IEnumerable<ReducedItem> script = await _mediator.Send(new GetUnmappedDevicesCommand(id));

        if (script == null)
        {
            return NotFound($"No unmapped script found with ID: {id}");
        }

        return Ok(script);
    }

    [HttpGet("Device/{id}/Unmapped")]
    public async Task<IActionResult> GetUnmappedScripts(int id)
    {
        IEnumerable<ReducedItem> script = await _mediator.Send(new GetUnmappedScriptsCommand(id));

        if (script == null)
        {
            return NotFound($"No unmapped script found with ID: {id}");
        }

        return Ok(script);
    }
}