using System.ComponentModel.DataAnnotations;

namespace RemoteControl.Rest.Persistence.Database.Models;

/// <summary>
///     Represents a device in the system.
///     Each device may be associated with multiple scripts through the
///     <see cref="DeviceScriptsMappings" />.
/// </summary>
public class Device
{
    /// <summary>
    ///     Gets or sets the unique identifier for the device.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    ///     Gets or sets the name of the device.
    /// </summary>
    [MaxLength(255)]
    public required string Name { get; set; }

    /// <summary>
    ///     Gets or sets the IP address of the device.
    /// </summary>
    [MaxLength(255)]
    public required string Ip { get; set; }

    /// <summary>
    ///     Gets or sets the MAC address of the device.
    /// </summary>
    [MaxLength(255)]
    public required string Mac { get; set; }

    /// <summary>
    ///     Gets or sets a value indicating whether the device is currently connected.
    /// </summary>
    public required bool Connected { get; set; }

    /// <summary>
    ///     Navigation property to the collection of
    ///     <see cref="DeviceScriptsMapping" />s.
    ///     Represents the scripts that are mapped to this device.
    /// </summary>
    public virtual ICollection<DeviceScriptsMapping>? DeviceScriptsMappings { get; set; }
}