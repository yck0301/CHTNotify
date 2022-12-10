using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CHTNotify.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class MemberController : ControllerBase
{
  
    /// <summary>
    /// 取得成員列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("list")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DDResponse<List<Member>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DDResponse<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult ListMembers(string sign)
    {
        try
        {
            if(sign == "")
            {
                return NotFound(new DDResponse<string>(-1, "NotFound"));
            }
            DDResponse<List<Member>> resp = new DDResponse<List<Member>>(0, new List<Member>());
            return Ok(resp);
        }
        catch (Exception)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest"));
        }

    }

    /// <summary>
    /// [管理者功能] 新增成員
    /// </summary>
    /// <returns></returns>
    [HttpPost("panel")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult AddMember(Member? member)
    {
        if(member == null)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest")); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 修改成員
    /// </summary>
    /// <returns></returns>
    [HttpPatch("panel/{memberId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult EditMember(Member? member)
    {
        if(member == null)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest")); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 刪除成員
    /// </summary>
    /// <returns></returns>
    [HttpDelete("panel/{memberId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult DeleteMember()
    {
        try
        {
            return Ok();
        }
        catch(Exception)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest")); 
        }
    }
}