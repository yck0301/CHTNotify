namespace CHTNotify;

public class DDResponse<T>
{
    /// <summary>
    /// 返回碼, 0成功, 非0失敗
    /// </summary>
    /// <example>0</example>
    public int returnCode { get; set; }

    /// <summary>
    /// 資料
    /// </summary>
    public T data { get; set; }

    public DDResponse(int _returnCode, T _data)
    {
        this.returnCode = _returnCode;
        this.data = _data;
    }
}