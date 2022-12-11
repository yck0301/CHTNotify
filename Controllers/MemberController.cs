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
    [HttpGet("list/{sign}/{groupId}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DDResponse<List<Member>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ListMembers(string sign, string groupId)
    {
        try
        {
            if(sign == "")
            {
                return NotFound();
            }
            DDResponse<List<Member>> resp = new DDResponse<List<Member>>(0, new List<Member>());
            return Ok(resp);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    /// <summary>
    /// [管理者功能] 新增成員
    /// </summary>
    /// <returns></returns>
    [HttpPost("panel/{sign}/{groupId}")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddMember(string sign, string groupId, Member? member)
    {
        if(member == null)
        {
            return BadRequest(); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 修改成員
    /// </summary>
    /// <returns></returns>
    [HttpPatch("panel/{sign}/{groupId}/{memberId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult EditMember(string sign, string groupId, string memberId, Member? member)
    {
        if(member == null)
        {
            return BadRequest(); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 刪除成員
    /// </summary>
    /// <returns></returns>
    [HttpDelete("panel/{sign}/{groupId}/{memberId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteMember(string sign, string groupId, string memberId)
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