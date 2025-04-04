using NLog;

namespace RemoteControl.Rest.Web.Extensions;

/// <summary>
///     Extension for logging options in regard to
///     <see cref="IConfiguration" />.
/// </summary>
internal static class LoggingExtensions
{
    /// <summary>
    ///     Logs the Kestrel endpoints configured in the application.
    /// </summary>
    /// <param name="configuration">The configuration instance.</param>
    /// <param name="logger">The logger instance.</param>
    internal static void LogKestrelEndpoints(this IConfiguration configuration,
        Logger logger)
    {
        IConfigurationSection kestrelEndpoints = configuration.GetSection("Kestrel:Endpoints");

        if (!kestrelEndpoints.Exists())
        {
            logger.Warn("No Kestrel endpoints are configured.");
            return;
        }

        foreach (IConfigurationSection endpoint in kestrelEndpoints.GetChildren())
        {
            string name = endpoint.Key;
            var url = endpoint.GetValue<string>("Url");
            logger.Info($"Configured Kestrel Endpoint - Name: {name}, URL: {url}");
        }
    }
}