using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Command-Handler for the <see cref="RemoveMappingCommand" />
///     <para>Removes a mapping between a script and a device from the database.</para>
/// </summary>
public class RemoveMappingCommandHandler : IRequestHandler<RemoveMappingCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public RemoveMappingCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RemoveMappingCommand request, CancellationToken cancellationToken)
    {
        DeviceScriptsMapping? mapping = await _context.DeviceScriptsMappings
            .FirstOrDefaultAsync(m =>
                    m.ScriptId == request.ScriptId && m.DeviceId == request.DeviceId,
                cancellationToken);

        if (mapping == null)
        {
            return false; // or throw a custom NotFoundException
        }

        _context.DeviceScriptsMappings.Remove(mapping);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}