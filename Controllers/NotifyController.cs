using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace CHTNotify.Controllers;

[ApiController]
[Route("[controller]")]

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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<HttpResponseMessage> PostLineNotify(LineNotify lineNotify)
    {
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", lineNotify.token);
        var content = new Dictionary<string, string>();
        content.Add("message", lineNotify.message);
        HttpResponseMessage response = await httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));
        
        return response;
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


    /// <summary>
    /// 取得發送群組
    /// </summary>
    /// <returns></returns>
    [HttpGet("group")] // http://domain/notify/group/g1
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void GetGroup()
    {
    }

    /// <summary>
    /// 編輯群組人員資料
    /// </summary>
    /// <returns></returns>
    [HttpPatch("group")] // http://domain/notify/group/g1?memberId=memberId1
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void PatchGroupMember(int memberId)
    {
    }

    /// <summary>
    /// 刪除群組人員資料
    /// </summary>
    /// <returns></returns>
    [HttpDelete("group")] // http://domain/notify/group/g1?memberId=memberId1
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void DeleteGroupMember(int memberId)
    {
    }
}