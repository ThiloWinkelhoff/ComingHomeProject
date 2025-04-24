using MediatR;
using RemoteControl.Rest.Common;

namespace RemoteControl.Rest.Processing.Commands
{
    /// <summary>
    ///     Command used to fetch a list of all scripts.
    /// </summary>
    public class GetScriptsCommand : IRequest<IEnumerable<ScriptDto>>
    {
        // No properties or parameters are required for this command.
    }
}