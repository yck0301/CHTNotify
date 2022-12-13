namespace CHTNotify;

public class FileResponse
{
  /// <summary>
  /// 返回碼: 0表成功, 非0失敗
  /// </summary>
  /// <example>0</example>
  public int returnCode { get; set; } = 0;

  /// <summary>
  /// 檔案路徑
  /// </summary>
  /// <example>resouce://file_path</example>
  public string filePath { get; set; } = String.Empty;
}