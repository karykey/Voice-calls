namespace Calls.HttpClient
{
    public interface IHttpResult<TResult>
    {
        string GetError();
        bool IsSuccess { get; }
        TResult Result { get; }
    }
}
