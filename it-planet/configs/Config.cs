using Newtonsoft.Json;

namespace it_planet.configs;

public class Config
{
    private ConfigStructure? _structure;

    public Config()
    {
        _structure = null;
    }
    
    /// <summary>
    /// Загружает конфигурацию из JSON файла, представленного по пути filepath.
    /// </summary>
    /// <param name="filepath">путь к файлу</param>
    public void Load(string filepath)
    {
        _structure = JsonConvert.DeserializeObject<ConfigStructure>(File.ReadAllText(filepath));
    }

    /// <summary>
    /// Генерирует строку для подключения к базе данных
    /// </summary>
    /// <returns>строка подключения</returns>
    public string GetDatabaseConnString()
    {
        if (_structure == null)
        {
            throw new NullReferenceException("config not load");
        }
        var database = _structure.Database;
        return string.Format("Host={0};Username={1};Password={2};Database={3}",
            database.Host,
            database.Username,
            database.Password,
            database.Database);
    }

    /// <summary>
    /// Возвращает порт сервера
    /// </summary>
    /// <returns>порт сервера</returns>
    public string GetPort()
    {
        if (_structure == null)
        {
            throw new NullReferenceException("config not load");
        }
        return _structure.Server.Port.ToString();
    }
}
