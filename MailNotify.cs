using System.ComponentModel.DataAnnotations;
namespace CHTNotify;

public class MailNotify
{
  /// <summary>
  /// 信件主旨
  /// </summary>
  /// <example>恭喜你!你是本產品第1,000,000個用戶!</example>
  [Required]
  public string subject { get; set; } = string.Empty;

  /// <summary>
  /// 信件內文
  /// </summary>
  /// <example>恭喜!你獲得信義區總價20億豪宅乙座!但須請您先匯回10%稅金, 共2億元</example>
  [Required]
  public string content { get; set; } = string.Empty;

  /// <summary>
  /// 上傳的圖檔路徑
  /// </summary>
  /// <example>resource://file_path</example>
  public string filePath { get; set; } = string.Empty;
}