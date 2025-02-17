using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControl.Rest.Processing.Api.Controller
{
    [ApiController]
    [Route("Skripts")]
    internal class SkriptsController : ControllerBase
    {
        public SkriptsController()
        {
        }

        [HttpGet(Name = "Devices")]
        public IEnumerable<string> GetSkripts()
        {
            return [];
        }
    }
}
