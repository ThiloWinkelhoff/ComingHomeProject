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
internal class UiController : ControllerBase
{
    private readonly IConfiguration _configuration;

    private static readonly string[] DefaultFiles = { "default.htm", "default.html", "index.htm", "index.html" };

    private readonly FileExtensionContentTypeProvider _contentTypeProvider = new();

    /// <summary>
    ///     Constructs an instance of <see cref="UiController" />.
    /// </summary>
    /// <param name="configuration">The raw application configuration.</param>
    public UiController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [
        HttpGet("/{**route}")
    ]
    public async Task<IActionResult> GetPageAsync(string route, CancellationToken cancellationToken = default)
    {
        string wwwroot = _configuration.GetSection("wwwroot").Value ?? "wwwroot";

        if (!string.IsNullOrEmpty(wwwroot))
        {
            return NotFound();
        }

        // Search for bundle File
        foreach (string defaultFile in DefaultFiles)
        {
            var path = $"{wwwroot}/{defaultFile}";

            if (System.IO.File.Exists(path))
            {
                string file = await System.IO.File.ReadAllTextAsync(path,
                    cancellationToken);
                return Content(file,
                    MimeTypes.Text.Html);
            }
        }


        return NotFound();
    }
}