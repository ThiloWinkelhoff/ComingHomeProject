using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Command handler for the <see cref="AddMappingCommand" />.
///     <para>
///         Handles the addition of a new mapping between a script and a device
///         in the database.
///     </para>
/// </summary>
public class AddMappingCommandHandler : IRequestHandler<AddMappingCommand, bool>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddMappingCommandHandler" />
    ///     class.
    /// </summary>
    /// <param name="context">
    ///     The <see cref="ApplicationDbContext" /> used for database operations.
    /// </param>
    public AddMappingCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Handles the <see cref="AddMappingCommand" /> to add a new mapping between a
    ///     script and a device.
    /// </summary>
    /// <param name="request">
    ///     The <see cref="AddMappingCommand" /> containing the IDs of the script and
    ///     device to be mapped.
    /// </param>
    /// <param name="cancellationToken">
    ///     The token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, with a <see cref="bool" />
    ///     result.
    ///     Returns <c>true</c> if the mapping was successfully added, otherwise
    ///     <c>false</c>.
    /// </returns>
    public async Task<bool> Handle(AddMappingCommand request, CancellationToken cancellationToken)
    {
        // Check if the mapping already exists in the database to avoid duplicates.
        bool exists = await _context.DeviceScriptsMappings.AnyAsync(m =>
                m.ScriptId == request.ScriptId && m.DeviceId == request.DeviceId,
            cancellationToken);

        // If the mapping already exists, return false.
        if (exists)
        {
            return false; // Or throw a custom AlreadyExistsException if desired.
        }

        // Create a new DeviceScriptsMapping.
        var mapping = new DeviceScriptsMapping
        {
            ScriptId = request.ScriptId,
            DeviceId = request.DeviceId
        };

        // Add the mapping to the database and save changes.
        _context.DeviceScriptsMappings.Add(mapping);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}