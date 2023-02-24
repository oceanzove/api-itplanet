using it_planet.repository.postgres.queries.location;

namespace it_planet.repository.location;

public interface ILocation
{
    public PostgresLocation Create(double latitude, double longitude);
}