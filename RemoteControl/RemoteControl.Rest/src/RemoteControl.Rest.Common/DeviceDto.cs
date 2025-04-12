namespace RemoteControl.Rest.Common
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public bool Connected { get; set; }

        public DeviceDto(int id, string name, string ip, string mac, bool connected)
        {
            Id = id;
            Name = name;
            Ip = ip;
            Mac = mac;
            Connected = connected;
        }
    }
}
