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
    /// <param name="lineNotify">Line 的 token 與你要打的訊息</param>
    /// <returns></returns>
    [HttpPost("line")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public async Task<IActionResult> PostLineNotify(LineNotify lineNotify)
    {
        try
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", lineNotify.token);
            var content = new Dictionary<string, string>();
            content.Add("message", lineNotify.message);
            HttpResponseMessage response = await httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));

            return Ok();
        }
        catch(Exception)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest"));
        }
    }

    /// <summary>
    /// 發送: Teams
    /// </summary>
    /// <returns></returns>
    [HttpPost("teams")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void PostTeamsNotify()
    {
    }

    /// <summary>
    /// 發送: 簡訊
    /// </summary>
    /// <returns></returns>
    [HttpPost("sms")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void PostSMSNotify()
    {
    }

    /// <summary>
    /// 發送: Email
    /// </summary>
    /// <returns></returns>
    [HttpPost("email")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void PostEmailNotify()
    {
    }

    /// <summary>
    /// 發送: 客製化平台
    /// </summary>
    /// <returns></returns>
    [HttpPost("someplace")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void PostSomeplaceNotify()
    {
    }
}