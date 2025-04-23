using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    public class GetUnmappedScriptsCommand : IRequest<IEnumerable<ReducedItem>>
    {
        public int DeviceId { get; set; }

        public GetUnmappedScriptsCommand(int deviceId)
        {
            DeviceId = deviceId;
        }
    }
}
