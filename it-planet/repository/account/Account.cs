using it_planet.repository.postgres;
using it_planet.repository.postgres.queries;
using Npgsql;

namespace it_planet.repository.account;

public class Account : RepositoryResponsibility, IAccount
{
    public Account(PostgresDatabase database, Queries queries) : base(database, queries) {}
    
    public PostgresAccount Create(string firstName, string lastName, string email, string password)
    {
        var query = Queries.Account.Create();
        return GetResultObject<PostgresAccount>(query, firstName, lastName, email, password);
    }

    public PostgresAccount Get(string email, string password)
    {
        var query = Queries.Account.Get();
        return GetResultObject<PostgresAccount>(query, email, password);
    }
}
