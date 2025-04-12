using System.Reflection;
using RemoteControl.Rest.Persistence;

namespace RemoteControl.Rest.Web.Extensions;

/// <summary>
///     Extensions for <see cref="MediatR" /> configuration.
/// </summary>
internal static class MediatRExtensions
{
    internal static void ConfigureMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(GetConnectedDevicesCommandHandler).Assembly
            );
        });
    }
}