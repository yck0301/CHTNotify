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
    /// <param name="sign">使用者簽章</param>
    /// <response code="200">取得歷史成功</response>
    /// <response code="404">找不到你的歷史</response>
    /// <response code="400">取得歷史失敗</response>
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