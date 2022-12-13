namespace CHTNotify;

public class History
{
    /// <summary>
    /// 歷史告警發送時間
    /// </summary>
    /// <example>2022-12-12</example>
    public string timestamp { get; set; } = String.Empty;

    /// <summary>
    /// 歷史告警發送者簽章
    /// </summary>
    /// <example>0806449</example>
    public string sign { get; set; } = String.Empty;

    /// <summary>
    /// 歷史告警內文
    /// </summary>
    /// <example>霹靂星球爆炸了, 霹靂貓乘太空船, 逃出來, 逃出來</example>
    public string content { get; set; } = String.Empty;
}