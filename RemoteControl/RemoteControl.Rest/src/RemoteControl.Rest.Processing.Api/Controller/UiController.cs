using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using RemoteControl.Rest.Processing.Api.config;

namespace RemoteControl.Rest.Processing.Api.Controller;

/// <summary>
///     A controller to serve the UI.
/// </summary>
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class UiController : ControllerBase
{
    private static readonly string[] DefaultFiles = { "default.htm", "default.html", "index.htm", "index.html" };
    private readonly IConfiguration _configuration;

    private readonly FileExtensionContentTypeProvider _contentTypeProvider = new();

    /// <summary>
    ///     Constructs an instance of <see cref="UiController" />.
    /// </summary>
    /// <param name="configuration">The raw application configuration.</param>
    public UiController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    ///     Serves UI resources based on the requested path.
    ///     If no path is provided, it attempts to return the default UI entry point.
    ///     The method searches for files in either the configured <c>wwwroot</c>
    ///     directory
    ///     or the default <c>web-client-planning</c> directory.
    /// </summary>
    /// <param name="catchAll">
    ///     The requested file path. If <c>null</c> or empty, the method returns the
    ///     default UI entry file.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to handle request cancellation.
    /// </param>
    /// <returns>
    ///     Returns the requested file content if found. If the file does not exist,
    ///     returns a <see cref="NotFoundResult" />.
    /// </returns>
    [
        HttpGet("/{**catchAll}")
    ]
    public async Task<IActionResult> GetPageAsync(string catchAll, CancellationToken cancellationToken = default)
    {
        // Sets the UI path to either the provided section in the configuration or selects the default web-client-planning.
        string wwwroot = _configuration.GetSection("wwwroot").Value ?? "web-client-planning";

        // Select the UI Entry-Point.
        var path = $"{wwwroot}/index.htm";

        // Checks if the Entry-Point Exists.
        if (System.IO.File.Exists(path))
        {
            // Reads the content that was requested with the catchAll.
            string file = await System.IO.File.ReadAllTextAsync(path,
                cancellationToken);

            // Returns the value.
            return Content(file,
                MimeTypes.Text.Html);
        }


        return NotFound();
    }
}