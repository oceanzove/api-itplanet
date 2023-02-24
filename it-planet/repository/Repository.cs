using it_planet.repository.location;
using it_planet.repository.account;
using it_planet.repository.postgres;
using it_planet.repository.postgres.queries;

namespace it_planet.repository;

public class Repository
{
    public IAccount Account;
    public ILocation Location;

    public Repository(PostgresDatabase database)
    {
        var queries = new Queries();
        Account = new Account(database, queries);
        Location = new Location(database, queries);
    }
}