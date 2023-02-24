using it_planet.repository.postgres;
using it_planet.repository.postgres.queries;
using it_planet.repository.postgres.queries.location;

namespace it_planet.repository.location;

public class Location : RepositoryResponsibility, ILocation
{
    public Location(PostgresDatabase database, Queries queries) : base(database, queries) {}

    public PostgresLocation Create(double latitude, double longitude)
    {
        var query = Queries.Location.Create();
        return GetResultObject<PostgresLocation>(query, latitude, longitude);
    }
    
}