using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Persistence.CommandHandlers
{
    /// <summary>
    ///     Command handler for the <see cref="GetUnmappedScriptsCommand" />.
    ///     <para>
    ///         Handles fetching scripts that are not yet mapped to the specified
    ///         device.
    ///     </para>
    /// </summary>
    public class GetUnmappedScriptsCommandHandler : IRequestHandler<GetUnmappedScriptsCommand, IEnumerable<ReducedItem>>
    {
        /// <summary>
        ///     The database context used to access the application's data.
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     Initializes a new instance of the
        ///     <see cref="GetUnmappedScriptsCommandHandler" /> class.
        /// </summary>
        /// <param name="context">
        ///     The <see cref="ApplicationDbContext" /> to interact with the database.
        /// </param>
        public GetUnmappedScriptsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Handles the <see cref="GetUnmappedScriptsCommand" /> by fetching scripts
        ///     that are not yet mapped
        ///     to the specified device.
        /// </summary>
        /// <param name="request">
        ///     The request containing the device ID for which to fetch unmapped scripts.
        /// </param>
        /// <param name="cancellationToken">
        ///     A token to monitor for cancellation requests.
        /// </param>
        /// <returns>
        ///     A list of <see cref="ReducedItem" /> objects representing the unmapped
        ///     scripts.
        /// </returns>
        public async Task<IEnumerable<ReducedItem>> Handle(GetUnmappedScriptsCommand request,
            CancellationToken cancellationToken)
        {
            // Retrieve scripts that are not yet mapped to the specified device
            List<Script> unmappedDevices = await _context.Scripts
                .Where(script => !script.DeviceScriptsMappings
                    .Any(mapping =>
                        mapping.DeviceId == request.DeviceId))
                .ToListAsync();

            // Convert the unmapped scripts to a list of ReducedItems
            return unmappedDevices.Select(script => new ReducedItem(script.Id,
                    script.ScriptName))
                .ToList();
        }
    }
}
