using Newtonsoft.Json;

namespace it_planet.configs;

public class ServerConfig
{
    [JsonProperty("port")]
    public int Port;
}