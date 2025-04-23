using MediatR;
using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Common;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Persistence.Database.Models;

namespace RemoteControl.Rest.Processing.Commands
{
    public class GetUnmappedScriptsCommandHandler : IRequestHandler<GetUnmappedScriptsCommand, IEnumerable<ReducedItem>>
    {
        /// <summary>
        ///     <inheritdoc cref="ApplicationDbContext" path="/summary" />
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///     DefaultConstructor for the database Command Handler.
        /// </summary>
        /// <param name="context"></param>
        public GetUnmappedScriptsCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReducedItem>> Handle(GetUnmappedScriptsCommand request,
            CancellationToken cancellationToken)
        {
            List<Script> unmappedDevices = await _context.Scripts
                .Where(script => !script.DeviceScriptsMappings
                    .Any(mapping =>
                        mapping.DeviceId ==
                        request.DeviceId))
                .ToListAsync();


            return unmappedDevices.Select(script => new ReducedItem(script.Id,
                    script.ScriptName))
                .ToList();
        }
    }
}
