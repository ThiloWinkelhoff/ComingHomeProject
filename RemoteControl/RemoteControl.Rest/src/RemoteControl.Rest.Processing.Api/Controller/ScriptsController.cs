using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RemoteControl.Rest.Processing.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class ScriptsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ScriptsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IEnumerable<string> GetAllScripts()
    {
        return new List<string> { "test1", "test2", "test3" };
    }

    [HttpGet("unlinked")]
    public IEnumerable<string> GetUnlinkedDevices()
    {
        string[] scriptList1 = { "a", "b", "c" };
        return scriptList1;
    }

    [HttpGet("inked")]
    public IEnumerable<string> GetLikedDevices(int scriptId)
    {
        string[] scriptList1 = { "a", "b", "c" };
        return scriptList1;
    }

    [HttpGet("{scriptId}/get-unlinked-devices")]
    public IEnumerable<string> GetConnectedDevices(int scriptId)
    {
        string[] scriptList1 = { "a", "b", "c" };
        string[] scriptList2 = { "d", "e", "f" };
        string[] scriptList3 = { "g", "h", "i" };
        var scriptMapping = new List<string[]>();
        scriptMapping.Add(scriptList1);
        scriptMapping.Add(scriptList2);
        scriptMapping.Add(scriptList3);
        return scriptMapping[scriptId];
    }

    [HttpGet("{scriptId}/get-linked-devices")]
    public IEnumerable<string> GetUnconnectedScripts(int scriptId)
    {
        string[] scriptList1 = { "a", "b", "c" };
        string[] scriptList2 = { "d", "e", "f" };
        string[] scriptList3 = { "g", "h", "i" };
        var scriptMapping = new List<string[]>();
        scriptMapping.Add(scriptList1);
        scriptMapping.Add(scriptList2);
        scriptMapping.Add(scriptList3);
        return scriptMapping[scriptId];
    }
}