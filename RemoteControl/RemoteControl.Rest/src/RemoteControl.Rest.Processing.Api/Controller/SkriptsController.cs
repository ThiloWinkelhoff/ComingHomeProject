using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RemoteControl.Rest.Processing.Api.Controller
{
    [ApiController]
    [Route("Skripts")]
    internal class SkriptsController : ControllerBase
    {
        public SkriptsController(IMediator mediator)
        {
            Mediator = mediator;
        }

        private IMediator Mediator { get; }

        [HttpGet(Name = "Devices")]
        public IEnumerable<string> GetSkripts()
        {
            return new List<string> { "test1", "test2", "test3" };
        }
    }
}
