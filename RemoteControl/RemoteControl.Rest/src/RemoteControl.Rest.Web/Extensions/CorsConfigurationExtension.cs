namespace RemoteControl.Rest.Web.Extensions;

/// <summary>
///     Provides extension methods to configure and apply CORS (Cross-Origin
///     Resource Sharing) policies.
/// </summary>
public static class CorsConfigurationExtension
{
    /// <summary>
    ///     The section name in the configuration file that defines the allowed CORS
    ///     origins.
    /// </summary>
    internal static readonly string CorsOriginSectionName = "CORS:Origins";

    /// <summary>
    ///     Configures CORS (Cross-Origin Resource Sharing) based on the
    ///     <c>"CORS:Origins"</c> section
    ///     in the provided <paramref name="configuration" />.
    ///     This method registers a CORS policy with the specified allowed origins.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" /> to which the CORS configuration will
    ///     be added.
    /// </param>
    /// <param name="configuration">
    ///     The <see cref="IConfiguration" /> containing the CORS configuration,
    ///     typically from a JSON file
    ///     (e.g., appsettings.json).
    /// </param>
    /// <param name="environment">
    ///     The current environment of the application (e.g., Development, Production).
    /// </param>
    /// <param name="policyName">
    ///     The name of the CORS policy that will be added to the service collection.
    /// </param>
    /// <param name="logger">
    ///     The <see cref="ILogger" /> instance used to log warnings or information
    ///     about the CORS configuration.
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the environment is not development, and the CORS origins are
    ///     configured with a wildcard ("*"),
    ///     which is restricted in non-development environments for security reasons.
    /// </exception>
    public static void ConfigureCors(this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment, string policyName, ILogger logger)
    {
        // Retrieves the CORS origin options from the configuration
        List<string>? origins = configuration.GetSection(CorsOriginSectionName).Get<string[]>()?.ToList();

        // If no origins are configured, log a warning and exit
        if (origins is null ||
            origins.Count == 0)
        {
            logger.LogWarning("CORS: No Origins were defined.");
            return;
        }

        // Log the allowed origins for CORS
        logger.LogInformation("CORS: Allowed CORS Origins: {origins}",
            origins);

        // Validate that a wildcard origin ("*") is only allowed in development environments
        foreach (string origin in origins.ToList())
        {
            if (string.Equals(origin,
                    "*",
                    StringComparison.Ordinal) &&
                !environment.IsDevelopment())
            {
                logger.LogWarning(
                    "CORS: Origin {origin} contains '*' which is only allowed in a development environment.",
                    origin);
                origins.Remove(origin);
            }
        }

        // Adds CORS services to the DI container with the specified policy, allowing any method and header
        services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                builder =>
                    builder
                        .WithOrigins(origins.ToArray()) // Allow specified origins
                        .AllowAnyMethod() // Allow any HTTP method (GET, POST, etc.)
                        .AllowAnyHeader() // Allow any HTTP header
            );
        });
    }

    /// <summary>
    ///     Applies the specified CORS policy to the application's request pipeline.
    ///     This middleware will ensure that the application respects the CORS policy
    ///     during requests.
    /// </summary>
    /// <param name="app">
    ///     The <see cref="IApplicationBuilder" /> used to configure the application's
    ///     request pipeline.
    /// </param>
    /// <param name="policyName">
    ///     The name of the CORS policy that will be applied.
    /// </param>
    /// <param name="logger"><see cref="ILogger" /> for logging purposes.</param>
    internal static void ApplyCors(this IApplicationBuilder app, string policyName, ILogger logger)
    {
        // Apply the CORS policy to the application pipeline
        app.UseCors(policyName);

        // Log the application of the CORS policy
        logger.LogInformation("CORS policy '{policyName}' applied.",
            policyName);
    }
}
