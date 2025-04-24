namespace RemoteControl.Rest.Persistence.Database.Models;

/// <summary>
///     Represents the mapping between a device and a script.
///     This class establishes a many-to-many relationship between
///     <see cref="Device" /> and <see cref="Script" />.
/// </summary>
public class DeviceScriptsMapping
{
    /// <summary>
    ///     Gets or sets the unique identifier of the device.
    ///     This is the foreign key referencing the <see cref="Device" />.
    /// </summary>
    public int DeviceId { get; set; }

    /// <summary>
    ///     Gets or sets the associated device for the mapping.
    ///     Represents the device that is mapped to a script.
    /// </summary>
    public virtual Device Device { get; set; }

    /// <summary>
    ///     Gets or sets the unique identifier of the script.
    ///     This is the foreign key referencing the <see cref="Script" />.
    /// </summary>
    public int ScriptId { get; set; }

    /// <summary>
    ///     Gets or sets the associated script for the mapping.
    ///     Represents the script that is mapped to a device.
    /// </summary>
    public virtual Script Script { get; set; }
}