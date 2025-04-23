namespace RemoteControl.Rest.Persistence.Database.Models;

public class DeviceScriptsMapping
{
    public int DeviceId { get; set; }
    public virtual Device Device { get; set; } // Navigation property to Device

    public int ScriptId { get; set; }
    public virtual Script Script { get; set; } // Navigation property to Script
}