namespace RemoteControl.Rest.Persistence.Database.Models;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<DeviceScript> DeviceScripts { get; set; } = new();
}
