using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RemoteControl.Rest.Processing.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class SkriptsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkriptsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("get-skripts")]
    public IEnumerable<string> GetSkripts()
    {
        return new List<string> { "test1", "test2", "test3" };
    }
}
