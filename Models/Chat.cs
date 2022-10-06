﻿using Newtonsoft.Json;

[Serializable]
public class Chat
{
    [JsonProperty(PropertyName ="name")]
    public string Name { get; set; }
    [JsonProperty(PropertyName ="message")]
    public string Message { get; set; }
}
