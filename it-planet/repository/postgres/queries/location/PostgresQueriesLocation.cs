namespace it_planet.repository.postgres.queries.location;

public class PostgresQueriesLocation : IQueriesLocation
{
    public string Create()
    {
        return "INSERT INTO \"LocationPoint\" (latitude, longitude) VALUES ($1, $2) RETURNING *";
    }
}