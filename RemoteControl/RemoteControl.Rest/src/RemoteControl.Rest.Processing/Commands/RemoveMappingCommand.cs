using MediatR;

namespace RemoteControl.Rest.Processing.Commands
{
    public class RemoveMappingCommand : IRequest<bool>
    {
        public int ScriptId { get; set; }
        public int DeviceId { get; set; }

        public RemoveMappingCommand(int scriptId, int deviceId)
        {
            DeviceId = deviceId;
            ScriptId = scriptId;
        }
    }
}
