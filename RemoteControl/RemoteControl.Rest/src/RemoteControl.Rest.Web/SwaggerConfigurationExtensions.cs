using Microsoft.OpenApi.Models;

namespace RemoteControl.Rest.Web;

/// <summary>
///     Provides configuration options for <c>Swagger</c> to document and interact
///     with the API.
/// </summary>
internal static class SwaggerConfigurationExtensions
{
    /// <summary>
    ///     Configures the <c>Swagger API documentation</c> for the application and
    ///     registers it with the <paramref name="services" />.
    ///     This includes setting up the Swagger version, description, and licensing
    ///     details for the API.
    /// </summary>
    /// <param name="services">
    ///     The <see cref="IServiceCollection" /> where Swagger services will be added
    ///     for API documentation and UI support.
    /// </param>
    internal static void AddSwaggerConfiguration(
        this IServiceCollection services)
    {
        // Adding Swagger documentation.
        services.AddSwaggerGen(options =>
        {
            // Adding Swagger Documentation
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "ISG Workplace Dashboard",
                    Version = "v1",
                    Description =
                        "This API allows the management of work-spaces within the Kaase buildings at IMA Schelling." +
                        "Currently it can read work-space information and their reservations.",
                    License = new OpenApiLicense
                    {
                        Name = "IMA Schelling"
                    },
                    Contact = new OpenApiContact
                    {
                        Email = "Lukas.Labudde@imaschelling.com",
                        Name = "API Support"
                    }
                });

            // Adding further swagger documentation.
            // Automatically takes summaries of directly accessed methods and
            // classes.
            string filePath = Path.Combine(AppContext.BaseDirectory,
                "Isg.Workplace.Dashboard.Processing.API.xml");
            options.IncludeXmlComments(filePath);
        });
    }
}