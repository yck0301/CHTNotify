using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mime;

namespace CHTNotify.Controllers;
/// <summary>
/// controller for upload large file
/// </summary>
[ApiController]
[Route("v1/[controller]")]
public class FileUploadController : ControllerBase
{
  private readonly ILogger<FileUploadController> _logger;

  public FileUploadController(ILogger<FileUploadController> logger)
  {
    _logger = logger;
  }

  /// <summary>
  /// 上傳圖檔
  /// </summary>
  /// <response code="200">發送成功</response>
  /// <response code="400">發送失敗</response>
  [HttpPost]
  [Consumes(MediaTypeNames.Application.Json)]
  [Produces("application/json")]
  [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileResponse))]
  [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
  public async Task<IActionResult> UploadLargeFile()
  {
    var request = HttpContext.Request;

    // validation of Content-Type
    // 1. first, it must be a form-data request
    // 2. a boundary should be found in the Content-Type
    if (!request.HasFormContentType ||
        !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
        string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
    {
      return new UnsupportedMediaTypeResult();
    }

    var reader = new MultipartReader(mediaTypeHeader.Boundary.Value, request.Body);
    var section = await reader.ReadNextSectionAsync();

    // This sample try to get the first file from request and save it
    // Make changes according to your needs in actual use
    while (section != null)
    {
      var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
          out var contentDisposition);

      if (hasContentDispositionHeader && contentDisposition.DispositionType.Equals("form-data") &&
          !string.IsNullOrEmpty(contentDisposition.FileName.Value))
      {
        // Don't trust any file name, file extension, and file data from the request unless you trust them completely
        // Otherwise, it is very likely to cause problems such as virus uploading, disk filling, etc
        // In short, it is necessary to restrict and verify the upload
        // Here, we just use the temporary folder and a random file name

        // Get the temporary folder, and combine a random file name with it
        var fileName = Path.GetRandomFileName();
        var saveToPath = Path.Combine(Path.GetTempPath(), fileName);

        using (var targetStream = System.IO.File.Create(saveToPath))
        {
          await section.Body.CopyToAsync(targetStream);
        }

        return Ok(new FileResponse());
      }

      section = await reader.ReadNextSectionAsync();
    }

    // If the code runs to this location, it means that no files have been saved
    return BadRequest(new ErrorResponse());
  }
}