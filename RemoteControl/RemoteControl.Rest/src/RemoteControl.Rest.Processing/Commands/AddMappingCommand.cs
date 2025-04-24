using MediatR;

namespace RemoteControl.Rest.Processing.Commands;

/// <summary>
///     Command to add a mapping between a script and a device.
/// </summary>
public class AddMappingCommand : IRequest<bool>
{
    /// <summary>
    ///     The ID of the script to be mapped.
    /// </summary>
    public int ScriptId { get; set; }

    /// <summary>
    ///     The ID of the device to be mapped.
    /// </summary>
    public int DeviceId { get; set; }

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddMappingCommand" /> class
    ///     with the specified script and device IDs.
    /// </summary>
    /// <param name="scriptId">
    ///     The ID of the script to be mapped.
    /// </param>
    /// <param name="deviceId">
    ///     The ID of the device to be mapped.
    /// </param>
    public AddMappingCommand(int scriptId, int deviceId)
    {
        DeviceId = deviceId;
        ScriptId = scriptId;
    }
}