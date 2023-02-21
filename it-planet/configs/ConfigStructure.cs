using Newtonsoft.Json;

namespace it_planet.configs;

public class ConfigStructure
{
    [JsonProperty("server")]
    public ServerConfig Server;
    
    [JsonProperty("database")]
    public DatabaseConfig Database;
}