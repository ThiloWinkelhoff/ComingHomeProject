using Microsoft.Extensions.FileProviders;

namespace RemoteControl.Rest.Web.Extensions
{
    /// <summary>
    ///     Extension class for configuring static file providers.
    /// </summary>
    public static class UseFileProvidersExtension
    {
        /// <summary>
        ///     Registers static file providers based on configured 'wwwroot' paths.
        ///     Supports multiple directories separated by '&' in the configuration value.
        ///     If a directory does not exist, it logs a warning and continues.
        /// </summary>
        /// <param name="applicationbuilder">The application's middleware builder.</param>
        /// <param name="logger">Logger instance for warnings and diagnostics.</param>
        /// <param name="configuration">Application configuration (expects 'wwwroot' key).</param>
        /// <param name="env">Hosting environment, used to resolve relative paths.</param>
        public static void UseFileProviders(this IApplicationBuilder applicationbuilder, ILogger logger,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            List<PhysicalFileProvider> fileProviders = new();

            // Read 'wwwroot' from config (supporting multiple paths via '&')
            foreach (string entry in (configuration.GetValue<string>("wwwroot") ?? "wwwroot").Split('&'))
            {
                // Make path absolute if it's not already
                string wwwroot = Path.IsPathFullyQualified(entry)
                    ? entry
                    : Path.Combine(env.ContentRootPath,
                        entry);

                try
                {
                    // Add a file provider if the directory exists
                    fileProviders.Add(new PhysicalFileProvider(wwwroot));
                }
                catch (DirectoryNotFoundException)
                {
                    // Warn but continue if the directory doesn't exist
                    logger.LogWarning("UI: The specified directory for wwwroot '{Path}' could not be found",
                        wwwroot);
                }
            }
            // Register the composite file provider for serving static files

            applicationbuilder.UseStaticFiles(new StaticFileOptions
                { FileProvider = new CompositeFileProvider(fileProviders) });
        }
    }
}
