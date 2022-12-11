using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace CHTNotify.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class NotifyController : ControllerBase
{

    HttpClient httpClient = new HttpClient();

    /// <summary>
    /// 發送: Line Notify
    /// </summary>
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組編號</param>
    /// <param name="commonNotify">token 與 你要打的訊息</param>
    /// <returns></returns>
    [HttpPost("line/{sign}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostLineNotify(string sign, string groupId, CommonNotify commonNotify)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", commonNotify.token);
            var content = new Dictionary<string, string>();
            content.Add("message", commonNotify.message);
            HttpResponseMessage response = await httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));

            return Ok();
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// 發送: Teams Notify
    /// </summary>
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組編號</param>
    /// <param name="commonNotify">token 與 你要打的訊息</param>
    /// <returns></returns>
    [HttpPost("teams/{sign}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostTeamsNotify(string sign, string groupId, CommonNotify commonNotify)
    {
        try
        {
            return Ok();
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// 發送: 簡訊
    /// </summary>
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組編號</param>
    /// <param name="commonNotify">token 與 你要打的訊息</param>
    /// <returns></returns>
    [HttpPost("sms/{sign}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostSMSNotify(string sign, string groupId, CommonNotify commonNotify)
    {
        try
        {
            return Ok();
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// 發送: Email
    /// </summary>
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組編號</param>
    /// <param name="commonNotify">token 與 你要打的訊息</param>
    /// <returns></returns>
    [HttpPost("email/{sign}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostEmailNotify(string sign, string groupId, CommonNotify commonNotify)
    {
        try
        {
            return Ok();
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }

    /// <summary>
    /// 發送: 客製化平台
    /// </summary>
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組編號</param>
    /// <param name="commonNotify">token 與 你要打的訊息</param>
    /// <returns></returns>
    [HttpPost("someplace/{sign}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult PostSomeplaceNotify(string sign, string groupId, CommonNotify commonNotify)
    {
        try
        {
            return Ok();
        }
        catch(Exception)
        {
            return BadRequest();
        }
    }
}