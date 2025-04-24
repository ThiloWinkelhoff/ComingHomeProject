using Microsoft.EntityFrameworkCore;
using RemoteControl.Rest.Persistence.Database;
using RemoteControl.Rest.Web.Extensions;

namespace RemoteControl.Rest.Web;

/// <summary>
///     Configures the startup settings for the project, specifying how the
///     application is initialized and configured.
///     This class is referenced in <see cref="Program" />.
/// </summary>
public class Startup
{
    /// <summary>
    ///     Gets the configuration settings for the application, such as user secrets
    ///     and other vital information.
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    ///     The environment the application is currently running in (e.g., Development,
    ///     Production).
    /// </summary>
    private readonly IWebHostEnvironment _env;

    /// <summary>
    ///     Name of the CORS policy that is applied to the application.
    /// </summary>
    private readonly string _policy = "CorsDefaultPolicy";

    /// <summary>
    ///     Initializes a new instance of the <see cref="Startup" /> class.
    /// </summary>
    /// <param name="configuration">
    ///     The configuration settings, typically injected via
    ///     dependency injection.
    /// </param>
    /// <param name="env">
    ///     The environment the application is running in (e.g.,
    ///     Development, Production).
    /// </param>
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        _configuration = configuration;
        _env = env;
    }

    /// <summary>
    ///     Configures the services required by the application.
    ///     This method is called by the runtime and used to add necessary services
    ///     like controllers, logging, authentication, and more.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" /> that is to be configured. This
    ///     collection contains all the services
    ///     the application will use (e.g., database context, authentication services,
    ///     etc.).
    /// </param>
    public void ConfigureServices(IServiceCollection services)
    {
        // Adds logging from the configured provider (e.g., NLog)
        services.AddLogging();

        // Create a service provider and obtain the logger to log service configurations
        using ServiceProvider serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetRequiredService<ILogger<Startup>>();
        logger.LogInformation("Startup: Configuring services...");

        // Adds the controllers that are used in the API
        services.AddControllers();

        // Adds support for configuration options
        services.AddOptions();

        // Adds Authentication and Authorization services
        services.AddAuthentication();
        services.AddAuthorization();

        // Adds MediatR configuration for handling requests and responses
        services.ConfigureMediatR();

        #if DEBUG
        // Adds Swagger documentation for the application, available only in the DEBUG environment
        services.AddSwaggerConfiguration();
        #endif

        // Configures CORS policies using the provided settings from the configuration and environment
        services.ConfigureCors(_configuration,
            _env,
            _policy,
            logger);

        // Configures the application database context with the connection string for SQL Server
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("ComingHomeDatabase")));
    }

    /// <summary>
    ///     Configures the HTTP request pipeline for the application.
    ///     This method is called by the runtime and is used to configure middleware
    ///     (e.g., routing, authentication, etc.).
    /// </summary>
    /// <param name="appBuilder">
    ///     The <see cref="IApplicationBuilder" /> used to configure the application's
    ///     request pipeline.
    /// </param>
    /// <param name="loggerFactory">
    ///     A factory used to create loggers for the application.
    /// </param>
    public void Configure(IApplicationBuilder appBuilder, ILoggerFactory loggerFactory)
    {
        ILogger<Startup> logger = loggerFactory.CreateLogger<Startup>();

        #if DEBUG
        // In development environment, enable detailed exception pages and Swagger UI
        appBuilder.UseDeveloperExceptionPage();
        appBuilder.ApplySwagger(logger);
        #endif

        // Apply the CORS policy globally
        appBuilder.ApplyCors(_policy,
            logger);

        // Set up routing for the application
        appBuilder.UseRouting();

        // Set up file providers and static file serving
        appBuilder.UseFileProviders(logger,
            _configuration,
            _env);
        appBuilder.UseDefaultFiles(); // Enable serving of default files (e.g., index.html)

        // Add authentication and authorization middleware
        appBuilder.UseAuthentication();
        appBuilder.UseAuthorization();

        // Map API controllers to routes
        appBuilder.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
