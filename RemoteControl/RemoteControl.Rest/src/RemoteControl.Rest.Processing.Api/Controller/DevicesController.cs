using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RemoteControl.Rest.Processing.Api.Controller
{
    [ApiController]
    [Route("Devices")]
    internal class DevicesController : ControllerBase
    {
        private IMediator _mediator;

        public DevicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "Skripts")]
        public IEnumerable<string> GetSkripts()
        {
            return new List<string> { "test1", "test2", "test3" };
        }

        [HttpGet(Name = "Mappigs")]
        public IEnumerable<string> GetMappigs()
        {
            return new List<string> { "test1", "test2", "test3" };
        }
    }
}
