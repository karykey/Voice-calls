namespace Calls.HttpClient
{
    public interface IHttpClient
    {
        IHttpResult<TResult> SendGetRequest<TResult>(string url);
        IHttpResult<TResult> SendPostRequest<TResult, TInput>(string url, TInput obj);
        string SendPostRequestLight(string requestUrl);
    }
}
