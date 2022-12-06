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
}