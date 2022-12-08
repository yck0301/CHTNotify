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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void ListGroups()
    {
    }

    /// <summary>
    /// [管理者功能] 新增群組
    /// </summary>
    /// <returns></returns>
    [HttpPost("editor")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void AddGroup(int groupId)
    {
    }

    /// <summary>
    /// [管理者功能] 編輯群組
    /// </summary>
    /// <returns></returns>
    [HttpPatch("editor/{groupId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void EditGroup(int groupId)
    {
    }

    /// <summary>
    /// [管理者功能] 刪除群組
    /// </summary>
    /// <returns></returns>
    [HttpDelete("editor/{groupId}")] // http://domain/notify/group/g1?memberId=memberId1
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void DeleteGroup(int groupId)
    {
    }
}