using Microsoft.Extensions.FileProviders;
using RemoteControl.Rest.Web.Extensions;

namespace RemoteControl.Rest.Web;

/// <summary>
///     Startup configuring the startup of a project, specified on
///     <see cref="Program" />
/// </summary>
public class Startup
{
    /// <summary>
    ///     Gets the configuration settings for the application.
    ///     Used to access user secrets and other vital information.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    ///     Environment the application is currently running as.
    /// </summary>
    private readonly IWebHostEnvironment _env;

    /// <summary>
    ///     Name of the policy that is added.
    /// </summary>
    private readonly string _policy = "CorsDefaultPolicy";

    /// <summary>
    ///     Default constructor for <see cref="Startup" />.
    /// </summary>
    /// <param name="configuration">
    ///     <inheritdoc cref="_configuration" path="/summary" />
    /// </param>
    /// <param name="env">
    ///     <see cref="IWebHostEnvironment" /> the application is
    ///     currently running in.
    /// </param>
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }

    /// <summary>
    ///     Configures <see cref="IServiceCollection" /> for the rest API.
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection" /> that is to be edited.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        // Adds Logging from NLog.
        services.AddLogging();

        // Adding the controllers that are used in the API.
        services.AddControllers();

        // Adding the support of options to the services
        services.AddOptions();

        // Adding Authentication and Authorization
        services.AddAuthentication();
        services.AddAuthorization();

        // Adding MediatR configuration
        services.ConfigureMediatR();

        // Adding Swagger Documentation to the application.
        services.AddSwaggerConfiguration();

        services.ConfigureCors(_configuration,
            _env,
            _policy);
    }

    /// <summary>
    ///     Configures <see cref="IApplicationBuilder" /> for the application.
    /// </summary>
    /// <param name="appBuilder">
    ///     <see cref="IApplicationBuilder" /> that is to be
    ///     configured.
    /// </param>
    public void Configure(IApplicationBuilder appBuilder, ILoggerFactory loggerFactory)
    {
        ILogger<Startup> logger = loggerFactory.CreateLogger<Startup>();
        if (_env.IsDevelopment())
        {
            // Enable Swagger and Swagger UI for development environment.
            appBuilder.UseDeveloperExceptionPage();
            appBuilder.ApplySwagger(logger);
        }
        else
        {
            // Force HTTPS in production.
            appBuilder.UseHsts();
        }

        List<PhysicalFileProvider> fileProviders = new();

        foreach (string entry in (_configuration.GetValue<string>("wwwroot") ?? "wwwroot").Split('&'))
        {
            string wwwroot = Path.IsPathFullyQualified(entry)
                ? entry
                : Path.Combine(_env.ContentRootPath,
                    entry);

            try
            {
                fileProviders.Add(new PhysicalFileProvider(wwwroot));
            }
            catch (DirectoryNotFoundException)
            {
                logger.LogWarning("The specified directory for wwwroot '{Path}' could not be found",
                    wwwroot);
            }
        }

        appBuilder.ApplyCors(_policy,
            logger);


        appBuilder.UseRouting();

        // Serve static files from wwwroot
        appBuilder.UseStaticFiles(new StaticFileOptions { FileProvider = new CompositeFileProvider(fileProviders) });
        appBuilder.UseDefaultFiles();

        // Authentication and Authorization
        appBuilder.UseAuthentication();
        appBuilder.UseAuthorization();

        appBuilder.UseEndpoints(endpoints =>
        {
            // Map API controllers
            endpoints.MapControllers();
        });
    }
}