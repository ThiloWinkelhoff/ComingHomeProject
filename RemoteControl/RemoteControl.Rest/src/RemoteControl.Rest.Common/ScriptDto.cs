namespace RemoteControl.Rest.Common
{
    public class ScriptDto : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<ReducedItem>? SubItems { get; set; }

        public ScriptDto(int id, string name, bool active, List<ReducedItem>? subItems)
        {
            Id = id;
            Name = name;
            Active = active;
            SubItems = subItems;
        }

        public ReducedItem ToReducedItem()
        {
            return new ReducedItem(Id,
                Name);
        }

        public static List<ReducedItem> ToReducedItemList(List<ScriptDto> scripts)
        {
            return scripts.Select(s => s.ToReducedItem()).ToList();
        }
    }
}
