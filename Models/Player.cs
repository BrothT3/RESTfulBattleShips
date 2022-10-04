using Newtonsoft.Json;

[Serializable]
public class Player
{
    public string Name { get; set; }
    public bool YourTurn { get; set; } = false;
}
