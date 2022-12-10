namespace CHTNotify;

public class DDResponse<T>
{
    public int returnCode { get; set; }
    public T data { get; set; }

    public DDResponse(int _returnCode, T _data)
    {
        this.returnCode = _returnCode;
        this.data = _data;
    }
}