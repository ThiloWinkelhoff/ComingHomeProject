namespace RemoteControl.Rest.Web.Extensions;

public static class CorsConfigurationExtension
{
    /// <summary>
    ///     Name of the section defining the configuration for the  by <c>CORS</c>
    ///     allowed <c>origins</c>.
    /// </summary>
    internal static readonly string CorsOriginSectionName = "CORS:Origins";

    /// <summary>
    ///     Configures CORS (Cross-Origin Resource Sharing) based on the
    ///     <c>"CORS:Origins"</c> section
    ///     of the provided <paramref name="configuration" />.
    /// </summary>
    /// <param name="services">
    ///     <see cref="IServiceCollection" /> to which the
    ///     <c>CORS</c> configuration is to be added to.
    /// </param>
    /// <param name="configuration">
    ///     <see cref="IConfiguration" /> containing the
    ///     <c>CORS</c> configuration that is to be red.
    /// </param>
    /// <param name="environment">The current environment of the application.</param>
    /// <param name="policyName">
    ///     Name under which the <c>CORS</c> policy should be added to
    ///     <paramref name="services" />.
    /// </param>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the environment is not development, and the CORS origins are
    ///     configured with a wildcard ("*"),
    ///     indicating exposure to all origins, which is restricted in non-development
    ///     environments for security reasons.
    /// </exception>
    public static void ConfigureCors(this IServiceCollection services,
        IConfiguration configuration,
        IWebHostEnvironment environment, string policyName, ILogger logger)
    {
        // Retrieves the CORS origin options from the configuration.
        List<string>? origins = configuration.GetSection(CorsOriginSectionName).Get<string[]>()?.ToList();

        // If no origins are configured, exit early to avoid unnecessary CORS setup.
        if (origins is null ||
            origins.Count == 0)
        {
            logger.LogWarning("CORS: No Origins were defined");
            return;
        }

        logger.LogInformation("CORS: Allowed CORS Origins: {origins}",
            origins);

        // Validate that a wildcard origin ("*") is only allowed in development environments.
        foreach (string origin in origins)
        {
            if (string.Equals(origin,
                    "*",
                    StringComparison.Ordinal) &&
                !environment.IsDevelopment())
            {
                logger.LogInformation(
                    """CORS: Origin {origin} contains "*" which is only allowed in an development environment.""",
                    origin);
                origins.Remove(origin);
            }
        }


        // Adds CORS services with the specified policy, allowing any method and any header.
        services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                builder =>
                    builder
                        .WithOrigins(origins.ToArray())
                        .AllowAnyMethod()
                        .AllowAnyHeader()
            );
        });
    }

    /// <summary>
    ///     Applies the specified <c>CORS</c> policy to the application request
    ///     pipeline.
    /// </summary>
    /// <param name="app">
    ///     The <see cref="IApplicationBuilder" /> to which the <c>CORS</c>
    ///     policy is applied.
    /// </param>
    /// <param name="policyName">
    ///     The name of the <c>CORS</c> policy that will be applied to
    ///     the application.
    /// </param>
    internal static void ApplyCors(this IApplicationBuilder app, string policyName, ILogger logger)
    {
        app.UseCors(policyName);
    }
}