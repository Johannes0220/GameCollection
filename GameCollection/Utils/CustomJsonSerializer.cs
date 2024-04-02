using Newtonsoft.Json;


namespace Utils
{
    public class CustomJsonSerializer : ICustomJsonSerializer
    {
        public JsonSerializer serializer;
    public CustomJsonSerializer()
    {
        serializer = new JsonSerializer();
    }

        public string Serialize(object obj)
        {
            using var writer = new StringWriter();
            
            serializer.Serialize(writer, obj);
            return writer.ToString();
        }

        public T Deserialize<T>(string json)
        {
            return serializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }
    }
}