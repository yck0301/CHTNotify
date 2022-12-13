namespace CHTNotify;

public class ErrorResponse
{
  /// <summary>
  /// 錯誤碼
  /// </summary>
  /// <example>7533967</example>
  public int errorCode { get; set; } = 7533967;

  /// <summary>
  /// 錯誤訊息
  /// </summary>
  /// <example>內內!錯了啦!</example>
  public string errorMessage { get; set; } = String.Empty;
}