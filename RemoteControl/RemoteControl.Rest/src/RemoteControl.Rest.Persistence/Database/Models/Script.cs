namespace RemoteControl.Rest.Persistence.Database.Models;

public class Script
{
    public int Id { get; set; }
    public string ScriptName { get; set; }

    public List<DeviceScript> DeviceScripts { get; set; } = new();
}
