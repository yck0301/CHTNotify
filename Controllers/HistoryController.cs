using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CHTNotify.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class HistoryController : ControllerBase
{
    /// <summary>
    /// 取得發送歷史
    /// </summary>
    /// <returns></returns>
    [HttpGet("list/{sign}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DDResponse<List<History>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ListHistory(string sign)
    {
        try
        {
            if (sign == "")
            {
                return NotFound();
            }
            return Ok(new DDResponse<List<History>>(0, new List<History>()));
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }
}