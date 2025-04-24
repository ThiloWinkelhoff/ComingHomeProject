using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Handles the <see cref="GetScriptsCommand" />, responsible for retrieving
///     all scripts from the database.
/// </summary>
/// <exception cref="Exception">
///     An exception might be thrown if there is an issue accessing the database or
///     mappings.
///     TODO: Replace with a custom exception for better error handling.
/// </exception>
public class GetScriptsCommandHandler : IRequestHandler<GetScriptsCommand, IEnumerable<ScriptDto>>
{
    /// <summary>
    ///     Database context used to access scripts and related data.
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GetScriptsCommandHandler" />
    ///     class.
    /// </summary>
    /// <param name="context">Injected application database context.</param>
    public GetScriptsCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Handles the incoming <see cref="GetScriptsCommand" /> and retrieves all
    ///     scripts from the database.
    /// </summary>
    /// <param name="request">
    ///     The request to get scripts (can be expanded in the future
    ///     for filtering, etc.).
    /// </param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>
    ///     A collection of <see cref="ScriptDto" /> representing scripts in the
    ///     database.
    /// </returns>
    public async Task<IEnumerable<ScriptDto>> Handle(GetScriptsCommand request, CancellationToken cancellationToken)
    {
        // Retrieve all scripts with their associated DeviceScriptsMappings and Device entities
        List<Script> scripts = await _context.Scripts
            .Include(script => script.DeviceScriptsMappings) // Eager load DeviceScriptsMappings
            .ThenInclude(mapping => mapping.Device) // Eager load the associated Device entity
            .ToListAsync(cancellationToken);

        // Map scripts to ScriptDto
        IEnumerable<ScriptDto> scriptDtos = scripts
            .Select(script => new ScriptDto(
                script.Id,
                script.ScriptName,
                script.DeviceScriptsMappings.IsNullOrEmpty(),
                script.DeviceScriptsMappings.IsNullOrEmpty()
                    ? null
                    : script.DeviceScriptsMappings.Select(mapping => new ReducedItem(
                            mapping.DeviceId,
                            mapping.Device.Name))
                        .ToList()));

        return scriptDtos;
    }
}
