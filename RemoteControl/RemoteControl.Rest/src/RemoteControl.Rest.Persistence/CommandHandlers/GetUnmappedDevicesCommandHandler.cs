using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Handles the <see cref="GetUnmappedDevicesCommand" /> to retrieve all
///     devices that are not mapped to a specific script.
/// </summary>
public class GetUnmappedDevicesCommandHandler : IRequestHandler<GetUnmappedDevicesCommand, IEnumerable<ReducedItem>>
{
    /// <summary>
    ///     The database context used to access device and script mapping data.
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    ///     Initializes a new instance of the
    ///     <see cref="GetUnmappedDevicesCommandHandler" /> class.
    /// </summary>
    /// <param name="context">
    ///     The application's database context, injected via
    ///     dependency injection.
    /// </param>
    public GetUnmappedDevicesCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Handles the <see cref="GetUnmappedDevicesCommand" /> by fetching devices
    ///     that are not mapped to the specified script.
    /// </summary>
    /// <param name="request">
    ///     The command containing the <c>ScriptId</c> used
    ///     to filter unmapped devices.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token used to cancel the operation if
    ///     necessary.
    /// </param>
    /// <returns>
    ///     A collection of <see cref="ReducedItem" /> representing the unmapped
    ///     devices, containing each device's <see cref="Device.Id" /> and
    ///     <see cref="Device.Name" />.
    /// </returns>
    public async Task<IEnumerable<ReducedItem>> Handle(GetUnmappedDevicesCommand request,
        CancellationToken cancellationToken)
    {
        // Get devices that do not have a mapping for the specified script
        List<Device> unmappedDevices = await _context.Devices
            .Where(device => !device.DeviceScriptsMappings
                .Any(mapping =>
                    mapping.ScriptId == request.ScriptId))
            .ToListAsync(cancellationToken);

        // Map the unmapped devices to ReducedItem containing just the ID and Name
        return unmappedDevices.Select(device => new ReducedItem(device.Id,
                device.Name))
            .ToList();
    }
}