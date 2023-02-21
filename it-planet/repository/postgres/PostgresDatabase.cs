using it_planet.configs;
using Npgsql;

namespace it_planet.repository.postgres;

public class PostgresDatabase
{
    private NpgsqlConnection? _connection;
    
    public PostgresDatabase(Config config)
    {
        var connectionString = config.GetDatabaseConnString();
        Connect(connectionString);
    }

    public NpgsqlConnection GetConnection() 
    {
        if (_connection == null)
        {
            throw new NullReferenceException("connection not initialized");
        }

        return _connection;
    }

    private void Connect(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }
}
