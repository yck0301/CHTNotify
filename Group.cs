namespace CHTNotify;

public class Group
{
    public string groupId { get; set; } = String.Empty;
    public string groupName { get; set; } = String.Empty;
    public List<Member> memberList { get; set; }
    public Group()
    {
        this.memberList = new List<Member>();
    }
}