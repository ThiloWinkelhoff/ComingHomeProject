namespace RemoteControl.Rest.Persistence.Database.Models;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ip { get; set; }
    public string Mac { get; set; }
    public bool Connected { get; set; }

    // Navigation property to DeviceScriptsMapping
    public ICollection<DeviceScriptsMapping> DeviceScriptsMappings { get; set; }
}