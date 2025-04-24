using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Command handler for the <see cref="RemoveMappingCommand" />.
///     <para>
///         Handles the removal of a mapping between a script and a device from
///         the database.
///     </para>
/// </summary>
public class RemoveMappingCommandHandler : IRequestHandler<RemoveMappingCommand, bool>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="RemoveMappingCommandHandler" /> class.
    /// </summary>
    /// <param name="context">
    ///     The <see cref="ApplicationDbContext" /> used for database operations.
    /// </param>
    public RemoveMappingCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Handles the <see cref="RemoveMappingCommand" /> to remove a mapping between
    ///     a script and a device.
    /// </summary>
    /// <param name="request">
    ///     The <see cref="RemoveMappingCommand" /> containing the IDs of the script
    ///     and device to be unmapped.
    /// </param>
    /// <param name="cancellationToken">
    ///     The token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    ///     A task representing the asynchronous operation, with a <see cref="bool" />
    ///     result.
    ///     Returns <c>true</c> if the mapping was successfully removed, otherwise
    ///     <c>false</c>.
    /// </returns>
    public async Task<bool> Handle(RemoveMappingCommand request, CancellationToken cancellationToken)
    {
        // Search for the device-script mapping to be removed.
        DeviceScriptsMapping? mapping = await _context.DeviceScriptsMappings
            .FirstOrDefaultAsync(m =>
                    m.ScriptId == request.ScriptId && m.DeviceId == request.DeviceId,
                cancellationToken);

        // If no mapping is found, return false.
        if (mapping == null)
        {
            return false; // or throw a custom NotFoundException if desired
        }

        // Remove the found mapping and save the changes to the database.
        _context.DeviceScriptsMappings.Remove(mapping);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}