using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Command-Handler for the <see cref="AddMappingCommand" />
///     <para>Adds a new mapping between a script and a device to the database.</para>
/// </summary>
public class AddMappingCommandHandler : IRequestHandler<AddMappingCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public AddMappingCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AddMappingCommand request, CancellationToken cancellationToken)
    {
        // Optional: Check for existing mapping to avoid duplicates
        bool exists = await _context.DeviceScriptsMappings.AnyAsync(m =>
                m.ScriptId == request.ScriptId && m.DeviceId == request.DeviceId,
            cancellationToken);

        if (exists)
        {
            return false; // Or throw a custom AlreadyExistsException
        }

        var mapping = new DeviceScriptsMapping
        {
            ScriptId = request.ScriptId,
            DeviceId = request.DeviceId
        };

        _context.DeviceScriptsMappings.Add(mapping);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}