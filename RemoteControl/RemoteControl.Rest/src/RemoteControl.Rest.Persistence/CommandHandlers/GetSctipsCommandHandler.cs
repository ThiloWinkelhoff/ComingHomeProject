using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Command-Handler for the <see cref="GetDevicesCommand" />
///     <para>Fetches <c>connected</c> devices from the <c>database</c></para>
/// </summary>
/// <exception cref="Exception">
///     // TODO: ADD CUSTOM EXCEPTION FOR MISSING
///     CONNNECTION OR OTHER EXCEPTIONS
/// </exception>
public class GetScriptsCommandHandler : IRequestHandler<GetScriptsCommand, IEnumerable<ScriptDto>>
{
    /// <summary>
    ///     <inheritdoc cref="ApplicationDbContext" path="/summary" />
    /// </summary>
    private readonly ApplicationDbContext _context;


    /// <summary>
    ///     DefaultConstructor for the database Command Handler.
    /// </summary>
    /// <param name="context"></param>
    public GetScriptsCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ScriptDto>> Handle(GetScriptsCommand request, CancellationToken cancellationToken)
    {
        // Get connected devices from the database
        List<Script> scripts = await _context.Scripts
            .ToListAsync(cancellationToken);

        // Map Device to DeviceDto (assuming you have a mapping method or AutoMapper)
        IEnumerable<ScriptDto> scriptDtos = scripts
            .Select(script => new ScriptDto(script.Id,
                script.ScriptName,
                script.DeviceScriptsMappings.IsNullOrEmpty(),
                script.DeviceScriptsMappings.IsNullOrEmpty()
                    ? null
                    : script.DeviceScriptsMappings.Select(mapping => new ReducedItem(mapping.DeviceId,
                            mapping.Device.Name))
                        .ToList()));

        return scriptDtos;
    }
}
