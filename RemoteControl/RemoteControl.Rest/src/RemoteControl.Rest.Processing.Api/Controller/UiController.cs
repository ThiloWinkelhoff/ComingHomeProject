using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace RemoteControl.Rest.Processing.Api.Controller;

/// <summary>
///     A controller to serve the UI.
/// </summary>
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class UiController : ControllerBase
{
    /// <summary>
    ///     <inheritdoc cref="FileExtensionContentTypeProvider" path="/summary" />
    /// </summary>
    private readonly FileExtensionContentTypeProvider _contentTypeProvider = new();

    /// <summary>
    ///     Path to the UI entry point.
    /// </summary>
    private readonly string _indexFile;

    /// <summary>
    ///     Constructs an instance of <see cref="UiController" />.
    /// </summary>
    /// <param name="configuration">The raw application configuration.</param>
    public UiController(IConfiguration configuration)
    {
        // Sets the path to the Index file of the UI Project
        _indexFile = Path.Combine(configuration.GetSection("wwwroot").Value ?? "wwwroot",
            "index.html");
    }

    /// <summary>
    ///     Serves the UI from the <c>index.html</c>.
    ///     In case assets or other files are requested refer to the
    ///     <c>UseStaticFiles</c> in the <c>Startup</c> which handles these requests.
    /// </summary>
    /// <param name="catchAll">
    ///     The requested path in the UI.
    /// </param>
    /// <param name="cancellationToken">
    ///     Token to handle request cancellation.
    /// </param>
    /// <returns>
    ///     Returns the requested UI path, in case the UI has been configured wrong, a
    ///     <see cref="NotFoundResult" /> will be returned.
    /// </returns>
    [HttpGet("/{**catchAll}")]
    [ProducesResponseType(typeof(byte[]),
        200)] // Success, file content
    [ProducesResponseType(404)] // Not Found if file doesn't exist
    [ProducesResponseType(500)] // Internal Server Error in case of I/O issues
    public async Task<IActionResult> GetPageAsync(string catchAll, CancellationToken cancellationToken = default)
    {
        // Check if the entry point of the UI exists.
        if (!System.IO.File.Exists(_indexFile))
        {
            return NotFound();
        }

        // Tries to get the type of the requested file.
        if (!_contentTypeProvider.TryGetContentType(_indexFile,
                out string contentType))
        {
            // Default content type
            contentType = "application/octet-stream";
        }

        // Reads the Index.html
        byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(_indexFile,
            cancellationToken);

        // Returns the Index File
        return File(fileBytes,
            contentType);
    }
}