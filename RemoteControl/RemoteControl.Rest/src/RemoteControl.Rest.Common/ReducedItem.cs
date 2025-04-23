namespace RemoteControl.Rest.Common
{
    public class ReducedItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ReducedItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
