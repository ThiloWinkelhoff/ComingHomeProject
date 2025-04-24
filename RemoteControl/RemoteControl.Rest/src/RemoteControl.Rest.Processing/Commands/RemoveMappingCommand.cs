using MediatR;

namespace RemoteControl.Rest.Processing.Commands
{
    /// <summary>
    ///     Command used to remove a mapping between a device and a script.
    ///     This command takes a ScriptId and a DeviceId to identify the mapping to be
    ///     removed.
    /// </summary>
    public class RemoveMappingCommand : IRequest<bool>
    {
        /// <summary>
        ///     The ID of the script involved in the mapping to be removed.
        /// </summary>
        public int ScriptId { get; set; }

        /// <summary>
        ///     The ID of the device involved in the mapping to be removed.
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="RemoveMappingCommand" />
        ///     class.
        /// </summary>
        /// <param name="scriptId">
        ///     The ID of the script to be unlinked from the device.
        /// </param>
        /// <param name="deviceId">
        ///     The ID of the device to be unlinked from the script.
        /// </param>
        public RemoveMappingCommand(int scriptId, int deviceId)
        {
            DeviceId = deviceId;
            ScriptId = scriptId;
        }
    }
}