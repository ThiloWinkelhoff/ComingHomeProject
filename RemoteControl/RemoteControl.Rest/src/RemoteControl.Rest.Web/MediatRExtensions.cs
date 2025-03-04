using System.Reflection;
using RemoteControl.Rest.Processing.Commands;

namespace RemoteControl.Rest.Web;

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
                typeof(GetConnectedDevicesAllTimeCommand).Assembly
            );
        });
    }
}