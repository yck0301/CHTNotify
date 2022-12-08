using System.ComponentModel.DataAnnotations;
namespace CHTNotify;

public class LineNotify
{
  /// <summary>
  /// Line的token
  /// </summary>
  [Required]
  public string token { get; set; } = string.Empty;

  /// <summary>
  /// 你要打的訊息
  /// </summary>
  [Required]
  public string message { get; set; } = string.Empty;
}