namespace RemoteControl.Rest.Persistence.Database.Models;

public class Script
{
    public int Id { get; set; }
    public string ScriptName { get; set; }

    // Navigation property to DeviceScriptsMapping
    public ICollection<DeviceScriptsMapping> DeviceScriptsMappings { get; set; } // Links to devices
}