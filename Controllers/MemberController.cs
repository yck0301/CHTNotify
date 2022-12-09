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
    [HttpGet("list/{groupId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void ListMembers(int groupId)
    {
    }

    /// <summary>
    /// [管理者功能] 增加成員
    /// </summary>
    /// <returns></returns>
    [HttpPost("editor")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void AddMember(int memberId)
    {
    }

    /// <summary>
    /// [管理者功能] 編輯成員
    /// </summary>
    /// <returns></returns>
    [HttpPatch("editor/{memberId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void EditMember(int memberId)
    {
    }

    /// <summary>
    /// [管理者功能] 刪除成員
    /// </summary>
    /// <returns></returns>
    [HttpDelete("editor/{memberId}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public void DeleteMember(int memberId)
    {
    }
}