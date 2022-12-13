namespace CHTNotify;

public class Group
{
    /// <summary>
    /// 群組ID
    /// </summary>
    /// <example>3345678</example>
    public string groupId { get; set; } = String.Empty;

    /// <summary>
    /// 群組名稱
    /// </summary>
    /// <example>木葉忍者村</example>
    public string groupName { get; set; } = String.Empty;

    /// <summary>
    /// 成員列表
    /// </summary>
    public List<Member> memberList { get; set; }
    public Group()
    {
        this.memberList = new List<Member>();
    }
}