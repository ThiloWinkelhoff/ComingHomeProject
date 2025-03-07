namespace RemoteControl.Rest.Web.Extensions;

/// <summary>
///     Extension to apply Swagger.
/// </summary>
internal static class SwaggerApplyingExtensions
{
    /// <summary>
    ///     Applies the <c>Swagger UI</c> to the application pipeline, making the API
    ///     documentation accessible through a web interface.
    /// </summary>
    /// <param name="app">
    ///     The <see cref="IApplicationBuilder" /> used to configure middleware in the
    ///     HTTP request pipeline.
    /// </param>
    /// <param name="loggerFactory">
    ///     The <see cref="ILoggerFactory" /> for creating loggers, used for logging
    ///     Swagger-related information during startup.
    /// </param>
    internal static void ApplySwagger(this IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        ILogger<Startup> logger = loggerFactory.CreateLogger<Startup>();
        var swagger = "/swagger/v1/swagger.json";

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(swagger,
                "Remote Control Rest API SWAGGER");
            options.RoutePrefix = "swagger"; // Serve Swagger at `/swagger`
        });

        logger.LogInformation("Swagger is used and may be accessed through /swagger");
    }
}
