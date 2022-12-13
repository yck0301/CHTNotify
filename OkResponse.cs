namespace CHTNotify;

public class OkResponse
{
  /// <summary>
  /// OK碼
  /// </summary>
  /// <example>0</example>
  public int OkCode { get; set; } = 0;

  /// <summary>
  /// Ok訊息
  /// </summary>
  /// <example>一些關於Ok的事情</example>
  public string OkMessage { get; set; } = String.Empty;
}