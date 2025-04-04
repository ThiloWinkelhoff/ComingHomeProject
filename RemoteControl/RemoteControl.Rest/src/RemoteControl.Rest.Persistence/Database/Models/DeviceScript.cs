namespace RemoteControl.Rest.Persistence.Database.Models;

public class DeviceScript
{
    public int DeviceId { get; set; }
    public Device Device { get; set; }

    public int ScriptId { get; set; }
    public Script Script { get; set; }
}