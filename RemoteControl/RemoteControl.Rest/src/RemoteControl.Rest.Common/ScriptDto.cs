namespace RemoteControl.Rest.Common
{
    /// <summary>
    ///     Data Transfer Object (DTO) representing a script.
    ///     Implements <see cref="IItem" /> to provide a simplified representation for
    ///     scripts.
    /// </summary>
    public class ScriptDto : IItem
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the script.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the script.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the active status of the script.
        ///     A script is considered active if this property is <c>true</c>.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     Gets or sets a list of <see cref="ReducedItem" /> representing the subitems
        ///     of the script.
        ///     This can be <c>null</c> if no subitems are associated with the script.
        /// </summary>
        public List<ReducedItem> SubItems { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ScriptDto" /> class.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier for the script.
        /// </param>
        /// <param name="name">
        ///     The name of the script.
        /// </param>
        /// <param name="active">
        ///     The active status of the script.
        /// </param>
        /// <param name="subItems">
        ///     A list of subitems associated with the script, or <c>null</c> if no
        ///     subitems are present.
        /// </param>
        public ScriptDto(int id, string name, bool active, List<ReducedItem>? subItems)
        {
            Id = id;
            Name = name;
            Active = active;
            SubItems = subItems ?? [];
        }

        /// <summary>
        ///     Converts the current <see cref="ScriptDto" /> to a
        ///     <see cref="ReducedItem" />.
        /// </summary>
        /// <returns>
        ///     A new <see cref="ReducedItem" /> that contains the Id and Name of the
        ///     script.
        /// </returns>
        public ReducedItem ToReducedItem()
        {
            return new ReducedItem(Id,
                Name);
        }

        /// <summary>
        ///     Converts a list of <see cref="ScriptDto" /> instances to a list of
        ///     <see cref="ReducedItem" /> instances.
        /// </summary>
        /// <param name="scripts">
        ///     The list of <see cref="ScriptDto" /> objects to convert.
        /// </param>
        /// <returns>
        ///     A list of <see cref="ReducedItem" /> objects representing the scripts.
        /// </returns>
        public static List<ReducedItem> ToReducedItemList(List<ScriptDto> scripts)
        {
            return scripts.Select(s => s.ToReducedItem()).ToList();
        }
    }
}
