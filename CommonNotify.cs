using System.ComponentModel.DataAnnotations;
namespace CHTNotify;

public class CommonNotify
{
  /// <summary>
  /// Line的token
  /// </summary>
  /// <example>7533967</example>
  [Required]
  public string token { get; set; } = string.Empty;

  /// <summary>
  /// 你要打的訊息
  /// </summary>
  /// <example>你的電話在我心裡響個不停, 好想拿起電話再說聲我愛你</example>
  [Required]
  public string message { get; set; } = string.Empty;

  /// <summary>
  /// 上傳的圖檔路徑
  /// </summary>
  /// <example>resource://file_path</example>
  public string filePath { get; set; } = string.Empty;
}