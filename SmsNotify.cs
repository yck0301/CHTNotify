using System.ComponentModel.DataAnnotations;
namespace CHTNotify;

public class SmsNotify
{
  /// <summary>
  /// 你要打的訊息
  /// </summary>
  /// <example>你的電話在我心裡響個不停, 好想拿起電話再說聲我愛你</example>
  [Required]
  public string message { get; set; } = string.Empty;
}