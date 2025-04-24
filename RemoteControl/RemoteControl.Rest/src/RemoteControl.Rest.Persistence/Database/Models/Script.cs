namespace RemoteControl.Rest.Persistence.Database.Models;

/// <summary>
///     Represents a script in the system.
///     Each script can be associated with multiple devices via the
///     <see cref="DeviceScriptsMappings" />.
/// </summary>
public class Script
{
    /// <summary>
    ///     Gets or sets the unique identifier for the script.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the script.
    /// </summary>
    public string ScriptName { get; set; }

    /// <summary>
    ///     Navigation property to the collection of
    ///     <see cref="DeviceScriptsMapping" />s.
    ///     This represents the devices that are mapped to this script.
    /// </summary>
    public virtual ICollection<DeviceScriptsMapping> DeviceScriptsMappings { get; set; } // Links to devices
}