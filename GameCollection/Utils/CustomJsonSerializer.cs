using Newtonsoft.Json;


namespace Utils
{
    public class CustomJsonSerializer
    {
        public CustomJsonSerializer()
        {

        }

        public string Serialize(object obj)
        {
            using var writer = new StringWriter();
            using var serializer = new JsonSerializer();
            serializer.Serialize(writer, obj);
            return writer.ToString();
        }

        public T Deserialize<T>(string json)
        {
            using var serializer = new JsonSerializer();
            return serializer.Deserialize<T>(new JsonTextReader(new JsonTextReader(new StringReader(json))));
        }
    }
}