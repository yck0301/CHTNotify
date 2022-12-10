using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CHTNotify.Controllers;

[ApiController]
[Route("v1/[controller]")]

public class GroupController : ControllerBase
{

    /// <summary>
    /// 取得群組列表
    /// </summary>
    /// <returns></returns>
    [HttpGet("list")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DDResponse<List<Group>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DDResponse<string>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult ListGroups(string sign)
    {
        try
        {
            if(sign == "")
            {
                return NotFound(new DDResponse<string>(-1, "NotFound"));
            }
            DDResponse<List<Group>> resp = new DDResponse<List<Group>>(0, new List<Group>());
            return Ok(resp);
        }
        catch (Exception)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest"));
        }

    }

    /// <summary>
    /// [管理者功能] 新增群組
    /// </summary>
    /// <returns></returns>
    [HttpPost("panel")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult AddGroup(Group? group)
    {
        if(group == null)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest")); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 修改群組
    /// </summary>
    /// <returns></returns>
    [HttpPatch("panel/{groupId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult EditGroup(Group? group)
    {
        if(group == null)
        {
            return BadRequest(new DDResponse<string>(-1, "BadRequest")); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 刪除群組
    /// </summary>
    /// <returns></returns>
    [HttpDelete("panel/{groupId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DDResponse<string>))]
    public IActionResult DeleteGroup()
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