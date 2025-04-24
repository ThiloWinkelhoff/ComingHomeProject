namespace RemoteControl.Rest.Common
{
    /// <summary>
    ///     Data Transfer Object (DTO) representing a device.
    ///     Implements <see cref="IItem" /> to provide a simplified representation for
    ///     devices.
    /// </summary>
    public class DeviceDto : IItem
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the device.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the name of the device.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the IP address of the device.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        ///     Gets or sets the MAC address of the device.
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        ///     Gets or sets the active status of the device.
        ///     A device is considered active if this property is <c>true</c>.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     Gets or sets a list of <see cref="ReducedItem" /> representing the subitems
        ///     of the device.
        ///     This can be <c>null</c> if no subitems are associated with the device.
        /// </summary>
        public List<ReducedItem> SubItems { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="DeviceDto" /> class.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier for the device.
        /// </param>
        /// <param name="name">
        ///     The name of the device.
        /// </param>
        /// <param name="ip">
        ///     The IP address of the device.
        /// </param>
        /// <param name="mac">
        ///     The MAC address of the device.
        /// </param>
        /// <param name="active">
        ///     The active status of the device.
        /// </param>
        /// <param name="subItems">
        ///     A list of subitems associated with the device, or <c>null</c> if no
        ///     subitems are present.
        /// </param>
        public DeviceDto(int id, string name, string ip, string mac, bool active, List<ReducedItem>? subItems)
        {
            Id = id;
            Name = name;
            Ip = ip;
            Mac = mac;
            Active = active;
            SubItems = subItems ?? [];
        }

        /// <summary>
        ///     Converts the current <see cref="DeviceDto" /> to a
        ///     <see cref="ReducedItem" />.
        /// </summary>
        /// <returns>
        ///     A new <see cref="ReducedItem" /> that contains the Id and Name of the
        ///     device.
        /// </returns>
        public ReducedItem ToReducedItem()
        {
            return new ReducedItem(Id,
                Name);
        }

        /// <summary>
        ///     Converts a list of <see cref="DeviceDto" /> instances to a list of
        ///     <see cref="ReducedItem" /> instances.
        /// </summary>
        /// <param name="devices">
        ///     The list of <see cref="DeviceDto" /> objects to convert.
        /// </param>
        /// <returns>
        ///     A list of <see cref="ReducedItem" /> objects representing the devices.
        /// </returns>
        public static List<ReducedItem> ToReducedItemList(List<DeviceDto> devices)
        {
            return devices.Select(d => d.ToReducedItem()).ToList();
        }
    }
}
