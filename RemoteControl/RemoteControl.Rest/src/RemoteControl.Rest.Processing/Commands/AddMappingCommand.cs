using MediatR;

namespace RemoteControl.Rest.Processing.Commands
{
    public class AddMappingCommand : IRequest<bool>
    {
        public int ScriptId { get; set; }
        public int DeviceId { get; set; }

        public AddMappingCommand(int scriptId, int deviceId)
        {
            DeviceId = deviceId;
            ScriptId = scriptId;
        }
    }
}
