using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    public class GetUnmappedDevicesCommand : IRequest<IEnumerable<ReducedItem>>
    {
        public int ScriptId { get; set; }

        public GetUnmappedDevicesCommand(int scriptId)
        {
            ScriptId = scriptId;
        }
    }
}
