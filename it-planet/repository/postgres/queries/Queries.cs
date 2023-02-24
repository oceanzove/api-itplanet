using it_planet.repository.postgres.queries.account;
using it_planet.repository.postgres.queries.location;

namespace it_planet.repository.postgres.queries;

public class Queries
{
    public IQueriesAccount Account;
    public IQueriesLocation Location;

    public Queries()
    {
        Account = new PostgresQueriesAccount();
        Location = new PostgresQueriesLocation();
    }
}

