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
    /// <param name="logger">
    ///     The <see cref="ILogger" /> for logging.
    /// </param>
    internal static void ApplySwagger(this IApplicationBuilder app, ILogger logger)
    {
        var swagger = "/swagger/v1/swagger.json";
        var swaggerRoute = "swagger";
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(swagger,
                "Remote Control Rest API SWAGGER");
            options.RoutePrefix = "swagger"; // Serve Swagger at `/swagger`
        });

        logger.LogInformation($"Swagger is used and may be accessed through /{swaggerRoute}");
    }
}
