using Calls.HttpClient.SerializationService;

namespace Calls.HttpClient
{
    public static class HttpClientFactory
    {
        public static IHttpClient CreateHttpClient()
        {
            ISerializationService serializationService = new SerializationService.SerializationService();
            return new global::Calls.HttpClient.HttpClient(serializationService);
        }
    }
}
