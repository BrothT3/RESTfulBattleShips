using Newtonsoft.Json;

[JsonObject, Serializable]
public class Player
{
    public string Name { get; set; }
    public bool YourTurn { get; set; } = false;
}
