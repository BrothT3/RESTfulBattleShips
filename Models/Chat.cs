using Newtonsoft.Json;

[JsonObject, Serializable]
public class Chat
{
    public string Name { get; set; }
    public string Message { get; set; }
}
