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
    [Route("Devices")]
    internal class DevicesController : ControllerBase
    {
        public DevicesController()
        {
        }

        [HttpGet(Name = "Skripts")]
        public IEnumerable<string> GetSkripts()
        {
            return [];
        }

        [HttpGet(Name = "Mappigs")]
        public IEnumerable<string> GetMappigs()
        {
            return [];
        }
    }
}
