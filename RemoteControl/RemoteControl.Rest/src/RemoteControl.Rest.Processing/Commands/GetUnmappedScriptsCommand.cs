using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    /// <summary>
    ///     Command used to fetch a list of scripts that are not mapped to a specific
    ///     device.
    ///     This command takes a DeviceId to identify the device whose unmapped scripts
    ///     are to be fetched.
    /// </summary>
    public class GetUnmappedScriptsCommand : IRequest<IEnumerable<ReducedItem>>
    {
        /// <summary>
        ///     The ID of the device for which unmapped scripts are to be retrieved.
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetUnmappedScriptsCommand" />
        ///     class.
        /// </summary>
        /// <param name="deviceId">
        ///     The ID of the device whose unmapped scripts are to be retrieved.
        /// </param>
        public GetUnmappedScriptsCommand(int deviceId)
        {
            DeviceId = deviceId;
        }
    }
}