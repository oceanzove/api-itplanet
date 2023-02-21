using it_planet.repository.postgres.queries.account;

namespace it_planet.repository.postgres.queries;

public class Queries
{
    public IQueriesAccount Account;

    public Queries()
    {
        Account = new PostgresQueriesAccount();
    }
}