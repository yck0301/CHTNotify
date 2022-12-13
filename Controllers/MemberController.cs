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
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組ID</param>
    /// <response code="200">取得成員列表成功</response>
    /// <response code="404">找不到成員列表</response>
    /// <response code="400">取得成員列表失敗</response>
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
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">群組ID</param>
    /// <param name="member">成員資料</param>
    /// <response code="200">新增成功</response>
    /// <response code="400">新增失敗</response>
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
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">要修改的群組ID</param>
    /// <param name="memberId">要修改的成員資料</param>
    /// <param name="member">要修改的成員資料</param>
    /// <response code="200">修改成功</response>
    /// <response code="400">修改失敗</response>
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
    /// <param name="sign">使用者簽章</param>
    /// <param name="groupId">要刪除的群組ID</param>
    /// <param name="memberId">要刪除的成員ID</param>
    /// <response code="200">刪除成功</response>
    /// <response code="400">刪除失敗</response>
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