namespace Calls.HttpClient.SerializationService
{
    public interface ISerializationService
    {
        string Serialize(object obj);
        TResult Deserialize<TResult>(string serializedObject);
    }
}
