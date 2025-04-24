using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    /// <summary>
    ///     Command used to fetch a list of devices that are not yet mapped to a given
    ///     script.
    ///     This command takes a <c>ScriptId</c> to identify the script whose unmapped
    ///     devices are to be fetched.
    /// </summary>
    public class GetUnmappedDevicesCommand : IRequest<IEnumerable<ReducedItem>>
    {
        /// <summary>
        ///     The ID of the script for which unmapped devices are to be retrieved.
        /// </summary>
        public int ScriptId { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetUnmappedDevicesCommand" />
        ///     class.
        /// </summary>
        /// <param name="scriptId">
        ///     The ID of the script whose unmapped devices are to be retrieved.
        /// </param>
        public GetUnmappedDevicesCommand(int scriptId)
        {
            ScriptId = scriptId;
        }
    }
}