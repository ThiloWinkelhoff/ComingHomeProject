using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers;

/// <summary>
///     Handles the <see cref="GetDevicesCommand" /> to retrieve all connected
///     devices from the database.
/// </summary>
/// <remarks>
///     Maps devices to <see cref="DeviceDto" /> including related script
///     information, if available.
/// </remarks>
public class GetDevicesCommandHandler : IRequestHandler<GetDevicesCommand, IEnumerable<DeviceDto>>
{
    /// <summary>
    ///     The database context used for accessing device data.
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GetDevicesCommandHandler" />
    ///     class.
    /// </summary>
    /// <param name="context">
    ///     The application's database context, injected via
    ///     dependency injection.
    /// </param>
    public GetDevicesCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Handles the request to retrieve all connected devices from the database.
    /// </summary>
    /// <param name="request">
    ///     The command request object (currently unused, but may
    ///     support filtering in the future).
    /// </param>
    /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
    /// <returns>
    ///     A collection of <see cref="DeviceDto" /> representing each connected
    ///     device, including mapped script references if any.
    /// </returns>
    public async Task<IEnumerable<DeviceDto>> Handle(GetDevicesCommand request, CancellationToken cancellationToken)
    {
        // Retrieve all devices with their associated DeviceScriptsMappings and Script data
        List<Device> connectedDevices = await _context.Devices
            .Include(device => device.DeviceScriptsMappings)
            .ThenInclude(mapping => mapping.Script) // Eager load the Script entity as well
            .ToListAsync(cancellationToken);

        // Map Device entities to DeviceDto, including associated script information if available
        IEnumerable<DeviceDto> deviceDtos = connectedDevices
            .Select(device => new DeviceDto(
                device.Id,
                device.Name,
                device.Ip,
                device.Mac,
                device.Connected,
                !device.DeviceScriptsMappings.IsNullOrEmpty()
                    ? device.DeviceScriptsMappings.Select(mapping => new ReducedItem(
                            mapping.ScriptId,
                            mapping.Script.ScriptName))
                        .ToList()
                    : null));

        return deviceDtos;
    }
}
