namespace Calls.HttpClient
{
    internal class HttpResult<TResult> : IHttpResult<TResult>
    {
        private readonly string _error;
        public HttpResult(TResult result, string error)
        {
            Result = result;
            _error = error;
        }

        public HttpResult(string error)
        {
            _error = error;
        }
        public string GetError()
        {
            return _error;
        }

        public bool IsSuccess
        {
            get { return _error == null; }
        }

        public TResult Result { get; private set; }
    }
}
