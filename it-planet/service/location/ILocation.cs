using it_planet.models.location;
using it_planet.repository.postgres.queries.location;

namespace it_planet.service.location;

public interface ILocation
{
    public PostgresLocation Create(CreateLocationInput props);
}