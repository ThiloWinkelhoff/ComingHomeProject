using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    /// <summary>
    ///     Command used to fetch a list of all devices.
    /// </summary>
    public class GetDevicesCommand : IRequest<IEnumerable<DeviceDto>>
    {
        // No properties or parameters are required for this command.
    }
}