using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;

namespace RemoteControl.Rest.Processing.Commands
{
    public class GetUnmappedDevicesCommandHandler : IRequestHandler<GetUnmappedDevicesCommand, IEnumerable<ReducedItem>>
    {
        /// <summary>
        ///     <inheritdoc cref="ApplicationDbContext" path="/summary" />
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     DefaultConstructor for the database Command Handler.
        /// </summary>
        /// <param name="context"></param>
        public GetUnmappedDevicesCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReducedItem>> Handle(GetUnmappedDevicesCommand request,
            CancellationToken cancellationToken)
        {
            List<Device> unmappedDevices = await _context.Devices
                .Where(device => !device.DeviceScriptsMappings
                    .Any(mapping =>
                        mapping.ScriptId ==
                        request.ScriptId))
                .ToListAsync();


            return unmappedDevices.Select(device => new ReducedItem(device.Id,
                    device.Name))
                .ToList();
        }
    }
}
