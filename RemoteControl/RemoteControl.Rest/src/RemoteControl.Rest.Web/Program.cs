using NLog;
using NLog.Extensions.Logging;
using RemoteControl.Rest.Web.Extensions;

namespace RemoteControl.Rest.Web;

/// <summary>
///     Entry point for the <see cref="RemoteControl.Rest.Web" /> Project.
///     initializing a <c>Microsoft.NET.Sdk.Web</c> process using the
///     <see cref="Startup" /> Project Configuration.
/// </summary>
public static class Program
{
    /// <summary>
    ///     Direct entry point for the <see cref="Program" />.
    /// </summary>
    /// <param name="args">Startup Arguments for the Application. </param>
    public static void Main(string[] args)
    {
        // Initialisation of the logger configuration
        Logger? logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

        logger.Info("Initialization: Starting");

        // Create and build the host
        IHost host = CreateHostBuilder(args).Build();

        // Logs the completion of the initialisation
        logger.Info("Initialization: Complete.");

        // Retrieves the Environment
        var env = host.Services.GetRequiredService<IHostEnvironment>();

        // Log Kestrel endpoints
        var configuration = host.Services.GetRequiredService<IConfiguration>();
        configuration.LogKestrelEndpoints(logger);

        logger.Info($"Initialisation: Running in {env.EnvironmentName} environment, starting to serve Requests");
        host.Run();
    }

    /// <summary>
    ///     Creates and configures a <see cref="IHostBuilder" />.
    /// </summary>
    /// <param name="args">Command line argument collection.</param>
    /// <returns>A configured <see cref="IHostBuilder" />.</returns>
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                IHostEnvironment env = context.HostingEnvironment;

                // Section only loaded in debug mode using the appsettings.json environment specific
                #if DEBUG
                config.AddJsonFile("appsettings.json",
                        false,
                        true)

                    // Load environment-specific config file based on current environment
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
                        true,
                        true);

                // Adding User Secrets in development
                if (env.IsDevelopment())
                {
                    // This line enables loading secrets during development
                    config.AddUserSecrets<Startup>();
                }

                #else
                // Load configuration from appsettings.json
                config.AddJsonFile("appsettings.json",
                        false,
                        true)

                    // Load environment-specific config file based on current environment
                    .AddJsonFile("appsettings.Production.json",
                        true,
                        true);
                #endif


                config.AddEnvironmentVariables();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddNLog();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel();
                webBuilder.UseStartup<Startup>();
            });
    }
}