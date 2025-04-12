﻿using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    public class GetConnectedDevicesCommand : IRequest<IEnumerable<DeviceDto>>
    {
    }
}
