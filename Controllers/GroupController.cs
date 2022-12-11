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
    [HttpGet("list/{sign}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DDResponse<List<Group>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ListGroups(string sign)
    {
        try
        {
            if(sign == "")
            {
                return NotFound();
            }
            DDResponse<List<Group>> resp = new DDResponse<List<Group>>(0, new List<Group>());
            return Ok(resp);
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    /// <summary>
    /// [管理者功能] 新增群組
    /// </summary>
    /// <returns></returns>
    [HttpPost("panel/{sign}")]
    [Produces("application/json")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddGroup(string sign, Group? group)
    {
        if(group == null)
        {
            return BadRequest(); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 修改群組
    /// </summary>
    /// <returns></returns>
    [HttpPatch("panel/{sign}/{groupId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult EditGroup(string sign, string groupId, Group? group)
    {
        if(group == null)
        {
            return BadRequest(); 
        }
        return Ok();
    }

    /// <summary>
    /// [管理者功能] 刪除群組
    /// </summary>
    /// <returns></returns>
    [HttpDelete("panel/{sign}/{groupId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteGroup(string sign, string groupId)
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