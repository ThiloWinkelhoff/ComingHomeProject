using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence;

/// <summary>
///     Command-Handler for the <see cref="GetConnectedDevicesCommand" />
///     <para>Fetches <c>connected</c> devices from the <c>database</c></para>
/// </summary>
/// <exception cref="Exception">
///     // TODO: ADD CUSTOM EXCEPTION FOR MISSING
///     CONNNECTION OR OTHER EXCEPTIONS
/// </exception>
public class GetConnectedDevicesCommandHandler : IRequestHandler<GetConnectedDevicesCommand, IEnumerable<DeviceDto>>
{
    /// <summary>
    ///     <inheritdoc cref="ApplicationDbContext" path="/summary" />
    /// </summary>
    private readonly ApplicationDbContext _context;


    /// <summary>
    ///     DefaultConstructor for the database Command Handler.
    /// </summary>
    /// <param name="context"></param>
    public GetConnectedDevicesCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    // Handling the request and returning the list of connected devices
    public async Task<IEnumerable<DeviceDto>> Handle(GetConnectedDevicesCommand request,
        CancellationToken cancellationToken)
    {
        // Get connected devices from the database
        List<Device> connectedDevices = await _context.Devices
            .Where(device => device.Connected)
            .ToListAsync(cancellationToken);

        // Map Device to DeviceDto (assuming you have a mapping method or AutoMapper)
        IEnumerable<DeviceDto> connectedDeviceDtos = connectedDevices
            .Select(device => new DeviceDto(device.Id,
                device.Name,
                device.Ip,
                device.Mac,
                device.Connected));

        return connectedDeviceDtos;
    }
}