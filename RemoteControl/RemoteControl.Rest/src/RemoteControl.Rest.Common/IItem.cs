namespace RemoteControl.Rest.Common;

public interface IItem
{
    int Id { get; set; }
    string Name { get; set; }
    bool Active { get; set; }
    List<ReducedItem> SubItems { get; set; }
}