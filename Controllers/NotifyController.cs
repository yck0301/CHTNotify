using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace CHTNotify.Controllers;

[ApiController]
[Route("[controller]")]

public class NotifyController : ControllerBase
{
    HttpClient httpClient = new HttpClient();

    [HttpPost("line")]
    public async Task<String> PostLineNotify(IFormCollection form)
    {
        string? token = form["token"];
        string? message = form["message"];
        if(token == null) {
            return "Token is null";
        }
        if(message == null) {
            return "Message is null";
        }

        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var content = new Dictionary<string, string>();
        content.Add("message", message);
        HttpResponseMessage response = await httpClient.PostAsync("https://notify-api.line.me/api/notify", new FormUrlEncodedContent(content));
        
        return response.StatusCode.ToString();
    }
}